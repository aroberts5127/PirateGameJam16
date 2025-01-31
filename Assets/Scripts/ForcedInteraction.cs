using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ForcedInteraction : MonoBehaviour
{
    [SerializeField]
    private iInteractable interactableObj;
    private PlayerState_Player playerState;

    private void Start()
    {
        interactableObj = GetComponent<iInteractable>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger Entered");
        if (other.GetComponent<PlayerState_Base>().PState == State.PLAYER)
        {
            //Debug.Log("Player");
            playerState = other.GetComponent<PlayerState_Player>();
            playerState?.setInteractableTarget(interactableObj);
            playerState.ForcePerformAction();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<PlayerState_Base>().PState == State.PLAYER)
        {
            playerState?.resetInteractableTarget();
            playerState = null;
        }
    }
}
