using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveModule : MonoBehaviour
{
    [SerializeField]
    private Toggle checkbox;

    [SerializeField]
    private TextMeshProUGUI objectiveText;

    private ObjectiveData objectiveData;
    private string countAddendum = string.Empty;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetData(ObjectiveData data)
    {
        objectiveData = data;
        checkbox.isOn = false;
        if(data.maxActionsNeeded > 1)
        {
            countAddendum = "(" + data.currentActionsProgress.ToString() + "/" + data.maxActionsNeeded.ToString() + ")";
        }
        objectiveText.text = data.description + " " + countAddendum;
    }

    public void UpdateCountAddendumText(ObjectiveData oData)
    {
        if(objectiveData.objectiveID == oData.objectiveID)
        {
            objectiveData.currentActionsProgress = oData.currentActionsProgress;
        }
        else
        {
            Debug.LogWarning("WTF");
        }
        if (objectiveData.maxActionsNeeded > 1)
        {
            countAddendum = "(" + objectiveData.currentActionsProgress.ToString() + "/" + objectiveData.maxActionsNeeded.ToString() + ")";
            objectiveText.text = objectiveData.description + " " + countAddendum;
        }
    }

    public void ResolveObjectiveCheck()
    {
        checkbox.isOn = true;
    }
}


