using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPromptSpriteLoader : MonoBehaviour
{

    public static InteractPromptSpriteLoader Instance;

    [SerializeField]
    private InteractPromptDataScriptableObject interactPromptData_so;
    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
    }

    
    public Sprite GetPromptSpriteByID(int id)
    {
        return interactPromptData_so.data[id].promptImage;
    }

}
