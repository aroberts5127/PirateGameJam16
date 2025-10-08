using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableVisuals : MonoBehaviour
{

    [SerializeField]
    //private GameObject interactPrompt;
    private iInteractable interactableParent;
    private PlayerState_Player playerState;
    [SerializeField]
    private PromptInfo[] promptData;
    // Start is called before the first frame update
    void Start()
    {
        playerState = null;
        //interactPrompt.SetActive(false);
        interactableParent = GetComponent<iInteractable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(this.gameObject.name);
        //Debug.Log(other.gameObject.name);
        if (other.GetComponent<PlayerState_Base>().PState == State.PLAYER)
        {        
            playerState = other.GetComponent<PlayerState_Player>();
            InteractPromptListener.ActivatePromptAction(promptData);
            //interactPrompt.SetActive(true);
            playerState?.setInteractableTarget(interactableParent);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<PlayerState_Base>().PState == State.PLAYER)
        {
            //interactPrompt.SetActive(false);
            InteractPromptListener.DeactivatePromptAction();
            playerState?.resetInteractableTarget();
            playerState = null;
        }
    }

    public void EnablePromptAction(PromptInfo[] prompts)
    {
        InteractPromptListener.DeactivatePromptAction();
        InteractPromptListener.ActivatePromptAction(prompts);
    }

    public void DisableInteractPrompt()
    {
        InteractPromptListener.DeactivatePromptAction();
        //interactPrompt.SetActive(false);
    }
}
