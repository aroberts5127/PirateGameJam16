using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableVisuals : MonoBehaviour
{

    [SerializeField]
    private GameObject interactPrompt;
    private iInteractable interactableParent;
    private PlayerState_Player playerState;
    // Start is called before the first frame update
    void Start()
    {
        playerState = null;
        interactPrompt.SetActive(false);
        interactableParent = GetComponent<iInteractable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerState_Base>().PState == State.PLAYER)
        {
            playerState = other.GetComponent<PlayerState_Player>();
            interactPrompt.SetActive(true);
            playerState?.setInteractableTarget(interactableParent);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<PlayerState_Base>().PState == State.PLAYER)
        {
            interactPrompt.SetActive(false);
            playerState?.resetInteractableTarget();
            playerState = null;
        }
    }

    public void DisableInteractPrompt()
    {
        interactPrompt.SetActive(false);
    }
}
