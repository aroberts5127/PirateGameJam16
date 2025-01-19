using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Weapon : PlayerState_Base, iDepossess, iInteractable, iControllable
{
    [SerializeField] GameObject geometry;
    [SerializeField] GameObject indicator;
    // Start is called before the first frame update
    void Start()
    {
        PState = State.WEAPON;
        indicator.SetActive(false);
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
        geometry.transform.position += Vector3.up;
        this.GetComponent<BoxCollider>().enabled = false;
        GetComponent<InteractableVisuals>().DisableInteractPrompt();
        origPlayerObject = interacter.gameObject;
        indicator.SetActive(true);
    }

    void iDepossess.depossess()
    {
        Debug.Log("Weapon Depossess Called");
        movementGO.SetParent(origPlayerObject.transform);
        movementGO.transform.position = origPlayerObject.transform.position;
        geometry.GetComponent<BoxCollider>().enabled = false;
        geometry.transform.position -= Vector3.up;
        this.GetComponent<BoxCollider>().enabled = true;
        indicator.SetActive(false);
    }
}
