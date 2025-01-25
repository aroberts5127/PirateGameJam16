using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Weapon : PlayerState_Base, iDepossess, iInteractable
{
    [SerializeField] GameObject geometry;
    [SerializeField] GameObject indicator;
    [SerializeField] GameObject hitBox;

    // Start is called before the first frame update
    void Start()
    {
        PState = State.WEAPON;
        indicator.SetActive(false);
    }

    void Update()
    {
        
    }

    public override void PerformAction(PlayerStats stats)
    {
        Debug.Log("Attacking");
        StartCoroutine(Attack(stats));
        //stats.SubtractStaminaForAction(GetComponent<iDepossess>());
    }


    void iInteractable.Interact()
    {
        //Debug.Log("here?");
        //Not Used by this class
    }
    void iInteractable.Interact(PlayerState_Player interacter)
    {
        //Debug.Log("Interacting with Weapon: " + gameObject.name);
        //Take Control
        movementGO = interacter.GetMovementGO();
        movementGO.SetParent(this.gameObject.transform);
        movementGO.transform.position = this.transform.position;
        geometry.GetComponent<Animator>().enabled = true;
        geometry.GetComponent<Animator>().Play("Rise");
        this.GetComponent<BoxCollider>().enabled = false;
        GetComponent<InteractableVisuals>().DisableInteractPrompt();
        origPlayerObject = interacter.gameObject;
        interacter.InvokePlayerInBody(false);
        indicator.SetActive(true);
    }

    void iDepossess.depossess()
    {
        //Debug.Log("Weapon Depossess Called");
        movementGO.SetParent(origPlayerObject.transform);
        movementGO.transform.position = origPlayerObject.transform.position;
        origPlayerObject.GetComponent<PlayerState_Player>().InvokePlayerInBody(true);
        //geometry.GetComponent<BoxCollider>().enabled = false;
        geometry.GetComponent<Animator>().Play("Falling");
        //geometry.transform.position -= Vector3.up;
        this.GetComponent<BoxCollider>().enabled = true;
        indicator.SetActive(false);
    }


    private IEnumerator Attack(PlayerStats stats)
    {
        hitBox.SetActive(true);
        //Geometry.GetComponent<Animator>().Play("Attack");
        yield return new WaitForSeconds(2.5f);
        stats.SubtractStaminaForAction(GetComponent<iDepossess>());
        hitBox.SetActive(false);

    }


}
