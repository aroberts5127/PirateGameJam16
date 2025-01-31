using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class StoryEvent : MonoBehaviour
{
    //Base Class for a Story Event, when making an event it will be attached to a game object, it will need some kind of listener to
    //control when it triggers, and what it does to the world.
    public int StoryEventID;
    [SerializeField]
    protected List<GameObject> objectsToEnable;
    [SerializeField]
    protected List<GameObject> objectsToDisable;
    [SerializeField]
    protected string dialogueID;
    protected DialogueData data;

    public virtual void Start()
    {
        if (dialogueID != string.Empty)
        {
            data = DialogueDataProvider.Instance.RetrieveDialogueByEventID(dialogueID);
            //Debug.Log("Data: " + data.textBody);
        }

    }


    public virtual void StartStoryEvent()
    {
        //This will remain empty, but may be usable in the future;
        return;
    }

    public virtual void ResolveStoryEvent()
    {

        Debug.Log("Resolving Story ID " + StoryEventID.ToString());
        if (objectsToEnable.Count > 0)
        {
            foreach (GameObject go in objectsToEnable)
            {
                go.SetActive(true);
            }
        }
        if (objectsToDisable.Count > 0)
        {
            foreach (GameObject go in objectsToDisable)
            {
                go.SetActive(false);
            }
        }
        if ( dialogueID != string.Empty)
        {
            CutsceneDialogueController.TriggerMonologueAction(data);
        }
        this.enabled = false;
    }
}
