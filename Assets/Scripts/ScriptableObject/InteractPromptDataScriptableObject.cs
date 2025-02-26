using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "InteractPromptData_SO", menuName = "ScriptableObjects/InteractPromptData", order = 0)]
public class InteractPromptDataScriptableObject : ScriptableObject
{
    public List<InteractPromptImageData> data;
}



[Serializable]
public struct InteractPromptImageData
{
    public int id;
    public string name;
    public Sprite promptImage;
}
