using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerState_Tool : PlayerState_Base, iDepossess, iInteractable
{
    [SerializeField]
    private GameObject geometry;
    // Start is called before the first frame update
    void Start()
    {
        PState = State.TOOL;
    }

    public override void PerformAction(PlayerStats stats)
    {
        Debug.Log("Tool Interact Firing");
        StartCoroutine(UseTool(stats));
    }

    private IEnumerator UseTool(PlayerStats stats)
    {
        movementGO.GetComponent<PlayerInput>().SetInputsOff();
        geometry.GetComponent<Animator>().SetTrigger("ActionTrigger");
        yield return new WaitForSeconds(0.5f);
        //hitBox.SetActive(true);
        //Geometry.GetComponent<Animator>().Play("Attack");
        yield return new WaitForSeconds(0.5f);
        stats.SubtractStaminaForAction(GetComponent<iDepossess>());
        //hitBox.SetActive(false);
        movementGO.GetComponent <PlayerInput>().SetInputsOn();
        base.PerformAction(stats);
    }


    void iInteractable.Interact()
    {
        //Not Used by this class
    }


   void iInteractable.Interact(PlayerState_Player interacter)
    {
        Debug.Log("Possessing Tool");
        //Need to Feedback and Take ownership of the PlayerInput Module;
        movementGO = interacter.GetMovementGO();
        movementGO.SetParent(this.gameObject.transform);
        movementGO.transform.position = this.transform.position;
        //movementGO.GetComponent<PlayerMotor>().SetAnimator(geometry.GetComponent<Animator>());
        geometry.GetComponent<Animator>().enabled = true;
        geometry.GetComponent<Animator>().Play("Rise");
        this.GetComponent<BoxCollider>().enabled = false;
        GetComponent<InteractableVisuals>().EnablePromptAction(actionTextInfo);
        origPlayerObject = interacter.gameObject;
        interacter.InvokePlayerInBody(false);
        //indicator.SetActive(true);
    }

    void iDepossess.depossess()
    {
        Debug.Log("Deposessing");
        movementGO.SetParent(origPlayerObject.transform);
        movementGO.transform.position = origPlayerObject.transform.position;
        origPlayerObject.GetComponent<PlayerState_Player>().InvokePlayerInBody(true);
        //geometry.GetComponent<BoxCollider>().enabled = false;
        geometry.GetComponent<Animator>().Play("Falling");
        //geometry.transform.position -= Vector3.up;
        this.GetComponent<BoxCollider>().enabled = true;
        InteractPromptListener.DeactivatePromptAction();
        //indicator.SetActive(false);
    }

    public override void performActionsCompleted()
    {
        base.performActionsCompleted();
        this.GetComponent<iDepossess>().depossess();
    }

}
