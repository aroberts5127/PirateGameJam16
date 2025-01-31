using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="CharacterDialogueRenderData_SO", menuName="ScriptableObjects/CharacterDialogueRenderData", order=0)]
public class PlayerDialogueScriptableObject : ScriptableObject
{
    public List<CharacterDialogueRenderStruct> CharacterList;

    public List<CharacterDialogueRenderStruct> GetRenderStruct()
    {
        return CharacterList;
    }
}

[Serializable]
public struct CharacterDialogueRenderStruct
{
    public int id;
    public string name;
    public RenderTexture renderTexture;
}
