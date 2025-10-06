using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractPromptListener : MonoBehaviour
{
    [SerializeField]
    private GameObject _interactPromptContainer;
    //[SerializeField]
    //private TextMeshProUGUI _interactText;
    [SerializeField]
    private GameObject promptPrefab;

    public static event Action<PromptInfo[]> activateInteractPromptAction;
    public static event Action deactivateInteractPromptAction;

    private Dictionary<int, PromptInfo> activePromptsDict = new Dictionary<int, PromptInfo>();

    private void Start()
    {
        activateInteractPromptAction += ActivateInteractPrompt;
        deactivateInteractPromptAction += DeactivateInteractPrompt;

        //activateInteractPromptAction?.Invoke(string.Empty);
    }

    public static void ActivatePromptAction(PromptInfo[] prompts)
    {
        activateInteractPromptAction?.Invoke(prompts);
    }

    public static void DeactivatePromptAction()
    {
        deactivateInteractPromptAction?.Invoke();
    }



    private void ActivateInteractPrompt2(string textInfo = "Interact")
    {
        //_interactText.text = textInfo;
        //_interactPrompt.SetActive(true);
    }

    private void ActivateInteractPrompt(PromptInfo[] prompts)
    {
        //_interactText.text = textInfo;
        foreach (Transform t in _interactPromptContainer.transform)
        {
            Destroy(t.gameObject);
        }
        foreach (PromptInfo prompt in prompts)
        {
            activePromptsDict.TryAdd(prompt.promptImageId, prompt);
        }
        foreach (int id in activePromptsDict.Keys)
        {
            //Debug.Log(id);
            GameObject go = Instantiate(promptPrefab, _interactPromptContainer.transform);
            go.GetComponent<InteractPromptObject>().SetData(activePromptsDict[id]);
        }
        
        _interactPromptContainer.SetActive(true);
    }

    private void DeactivateInteractPrompt()
    {
        _interactPromptContainer.SetActive(false);
        foreach(Transform t in _interactPromptContainer.transform)
        {
            Destroy(t.gameObject);
        }
        activePromptsDict.Clear();
    }

    private void OnDestroy()
    {
        //Debug.Log("I Did this");
        activateInteractPromptAction -= ActivateInteractPrompt;
        deactivateInteractPromptAction -= DeactivateInteractPrompt;
    }
}


[Serializable]
public struct PromptInfo
{
    public string textInfo;
    public int promptImageId;
}
