using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Weapon : PlayerState_Base, iDepossess, iInteractable, iControllable
{
    [SerializeField] GameObject geometry;
    // Start is called before the first frame update
    void Start()
    {
        PState = State.WEAPON;
    }

    public override void PerformAction()
    {
        Debug.Log("Attacking");
    }


    void iInteractable.Interact(PlayerState_Player interacter)
    {
        Debug.Log("Interacting with Weapon: " + gameObject.name);
        //Take Control
        movementGO = interacter.GetMovementGO();
        movementGO.SetParent(this.gameObject.transform);
        movementGO.transform.position = this.transform.position;
        geometry.GetComponent<BoxCollider>().enabled = true;
        GetComponent<InteractableVisuals>().DisableInteractPrompt();
    }

    void iDepossess.depossess()
    {
        Debug.Log("Weapon Depossess Called");
    }
}
