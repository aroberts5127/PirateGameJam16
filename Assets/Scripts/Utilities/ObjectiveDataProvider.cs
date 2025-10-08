using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ObjectiveDataProvider : MonoBehaviour
{
    public static ObjectiveDataProvider Instance;
    public Dictionary<string, ObjectiveData> objectiveDataSet;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        objectiveDataSet = new Dictionary<string, ObjectiveData>();
        ImportObjectivesFromResource();
    }

    private void ImportObjectivesFromResource()
    {
        objectiveDataSet.Clear();
        TextAsset objectiveTA = Resources.Load<TextAsset>("objectiveSystemData");
        if (objectiveTA != null)
        {
            string csvText = objectiveTA.text;
            StringReader reader = new StringReader(csvText);
            string headerline = reader.ReadLine();
            string[] headers = headerline.Split(',');

            string line;
            ObjectiveData objectiveData;
            objectiveData.objectiveID = "";
            objectiveData.description = "";
            objectiveData.currentActionsProgress = 0;
            objectiveData.maxActionsNeeded = 0;
            string dictKey = "";
            while ((line = reader.ReadLine()) != null)
            {
                string[] values = line.Split(",");
                for (int i = 0; i < values.Length; i++)
                {
                    string key = headers[i];
                    string data = values[i];
                    if (key == "objectiveID")
                    {
                        dictKey = data;
                        objectiveData.objectiveID = data;
                    }
                    if (key == "description")
                    {
                        objectiveData.description = data;
                    }
                    if (key == "maxActionsNeeded")
                    {
                        objectiveData.maxActionsNeeded = int.Parse(data);
                    }
                }
                //Debug.Log("KEY: " + dictKey + ", DATA: " + objectiveData.objectiveID + ", " + objectiveData.description + ", " + objectiveData.maxActionsNeeded.ToString());
                objectiveDataSet.Add(dictKey, objectiveData);

            }
        }

    }

    public ObjectiveData RetrieveObjectiveByEventID(string eventID)
    {
        return objectiveDataSet[eventID];
    }
}
