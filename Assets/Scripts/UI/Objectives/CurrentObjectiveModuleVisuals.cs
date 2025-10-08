using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentObjectiveModuleVisuals : MonoBehaviour
{

    public static event Action<bool> ObjectiveModuleToggleAction;
    private bool isShowing;

    [SerializeField]
    private Animator animator;

    private Coroutine autoHideRoutine;

    private float autoHideWaitTime = 5.0f;
    private WaitForSeconds autoHideWaitForTime;
    // Start is called before the first frame update
    void Start()
    {
        isShowing = false;
        ObjectiveModuleToggleAction += ShowOrHideObjectiveModule;
        autoHideWaitForTime = new WaitForSeconds(autoHideWaitTime);
        //ShowOrHideObjectiveModule();
        //animator.SetTrigger("HideTrigger");
    }

    private void ShowOrHideObjectiveModule(bool forceShow=false)
    {
        if (forceShow)
        {
            if (autoHideRoutine != null)
                StopCoroutine(autoHideRoutine);
            isShowing = true;
            animator.SetTrigger("ShowTrigger");
            autoHideRoutine = StartCoroutine(AutoHideObjectiveModule());
            return;
        }
        if (isShowing)
        {
            isShowing = false;
            animator.SetTrigger("HideTrigger");
            if(autoHideRoutine != null)
                StopCoroutine(autoHideRoutine);
        }
        else
        {
            isShowing = true;
            animator.SetTrigger("ShowTrigger");
            autoHideRoutine = StartCoroutine(AutoHideObjectiveModule());
        }
    }

    private IEnumerator AutoHideObjectiveModule()
    {
        yield return autoHideWaitForTime;
        ShowOrHideObjectiveModule();
    }

    public static void CurrentObjectiveTrigger(bool forceShow=false) 
    {
        ObjectiveModuleToggleAction?.Invoke(forceShow);
    }
}
