using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractPromptObject : MonoBehaviour
{
    [SerializeField]
    private Image promptImage;
    [SerializeField]
    private TextMeshProUGUI promptText;

    public void SetData(PromptInfo prompt)
    {
        promptText.text = prompt.textInfo;
        promptImage.sprite = InteractPromptSpriteLoader.Instance.GetPromptSpriteByID(prompt.promptImageId);
    }
}
