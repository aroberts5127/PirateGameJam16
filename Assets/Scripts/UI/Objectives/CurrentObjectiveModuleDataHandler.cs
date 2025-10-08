using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CurrentObjectiveModuleDataHandler : MonoBehaviour
{
    [SerializeField]
    private Transform objectiveParentTransform;
    private GameObject objectivePrefab;
    private ObjectiveModule objectiveModule;

    public static event Action<ObjectiveData> newObjectiveLoading;
    public static event Action AttemptToProgressObjective;
    public static event Action ResolveObjectiveEvent;
    private ObjectiveData currentObjective;

    private void Start()
    {
        newObjectiveLoading += UpdateCurrentObjective;
        AttemptToProgressObjective += ProgressCurrentObjective;
        ResolveObjectiveEvent += ResolveObjective;
        objectivePrefab = Resources.Load("Prefabs/ObjectiveBox") as GameObject;
    }

    private void ClearCurrentObjectives()
    {
        for (int i = 0; i < objectiveParentTransform.childCount; i++)
        {
            //Convert this to use ObjectPooling
            Destroy(objectiveParentTransform.GetChild(i).gameObject);
        }
        objectiveModule = null;
    }

    private void UpdateCurrentObjective(ObjectiveData data)
    {
        ClearCurrentObjectives();
        currentObjective = data;
        //Convert To Object Pool
        GameObject objectiveGo = Instantiate(objectivePrefab, objectiveParentTransform, false);
        objectiveModule = objectiveGo.GetComponent<ObjectiveModule>();
        objectiveModule.SetData(currentObjective);
        
    }

    public static void SendNewObjective(ObjectiveData data)
    {
        newObjectiveLoading?.Invoke(data);
    }

    private void ProgressCurrentObjective()
    {
        if (currentObjective.maxActionsNeeded > 1)
        {
            currentObjective.currentActionsProgress++;
            objectiveModule.UpdateCountAddendumText(currentObjective);
        }
    }

    public static void SendObjectiveUpdate()
    {
        AttemptToProgressObjective?.Invoke();
    }

    private void ResolveObjective()
    {
        CurrentObjectiveModuleVisuals.CurrentObjectiveTrigger(true);
        objectiveModule.ResolveObjectiveCheck();
    }

    public static void ResolveObjectiveTrigger()
    {
        ResolveObjectiveEvent?.Invoke();
    }
    
}
