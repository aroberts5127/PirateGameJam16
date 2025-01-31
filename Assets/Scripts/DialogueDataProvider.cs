using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueDataProvider : MonoBehaviour
{
    public static DialogueDataProvider Instance;
    public Dictionary<string, DialogueData> dialogueDataSet;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        dialogueDataSet = new Dictionary<string, DialogueData>();
        ImportDialogueFromResource();
    }

    private void ImportDialogueFromResource()
    {
        dialogueDataSet.Clear();
        TextAsset dialoguedata = Resources.Load<TextAsset>("dialogueSystemText");
        if (dialoguedata != null)
        {
            string csvText = dialoguedata.text;
            StringReader reader = new StringReader(csvText);
            string headerline = reader.ReadLine();
            string[] headers = headerline.Split(',');

            string line;
            DialogueData dialogueData;
            dialogueData.eventId = "";
            dialogueData.textBody = "";
            dialogueData.nextEventId = "";
            dialogueData.speaker1 = -1;
            dialogueData.speaker2 = -1;
            string dictKey = "";
            while ((line = reader.ReadLine()) != null)
            {
                string[] values = line.Split(",");
                for (int i = 0; i < values.Length; i++)
                {
                    
                    string key = headers[i];
                    Debug.Log(i + " " + key);
                    string data = values[i];
                    if (key == "eventID")
                    {
                        dictKey = data;
                        dialogueData.eventId = data;
                    }
                    if(key == "speaker1")
                    {
                        dialogueData.speaker1 = int.Parse(data);
                    }
                    if(key == "speaker2")
                    {
                        dialogueData.speaker2 = int.Parse(data);
                    }
                    if(key == "text")
                    {
                        dialogueData.textBody = data;
                    }
                    if(key == "nextEventId")
                    {
                        dialogueData.nextEventId = data;
                    }
                }
                //Debug.Log("KEY: " + dictKey + ", DATA: " + dialogueData.speaker1 + ", " + dialogueData.speaker2 + ", " + dialogueData.textBody);
                dialogueDataSet.Add(dictKey, dialogueData);

            }
        }
        
    }

    public DialogueData RetrieveDialogueByEventID(string eventID)
    {
        return dialogueDataSet[eventID];
    }
    
   
}
