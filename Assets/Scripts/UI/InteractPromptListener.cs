using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractPromptListener : MonoBehaviour
{
    [SerializeField]
    private GameObject _interactPrompt;
    [SerializeField]
    private TextMeshProUGUI _interactText;

    public static event Action<string> activateInteractPromptAction;
    public static event Action deactivateInteractPromptAction;

    private void Start()
    {
        activateInteractPromptAction += ActivateInteractPrompt;
        deactivateInteractPromptAction += DeactivateInteractPrompt;

        activateInteractPromptAction?.Invoke(string.Empty);
    }

    public static void ActivatePromptAction(string prompt)
    {
        activateInteractPromptAction?.Invoke(prompt);
    }

    public static void DeactivatePromptAction()
    {
        deactivateInteractPromptAction?.Invoke();
    }



    private void ActivateInteractPrompt(string textInfo = "Interact")
    {
        _interactText.text = textInfo;
        _interactPrompt.SetActive(true);
    }

    private void DeactivateInteractPrompt()
    {
        _interactPrompt.SetActive(false);
    }
}
