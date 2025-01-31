using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryInteractable : MonoBehaviour, iInteractable
{
    private StoryEvent eventToInteractWith;
    public void Interact()
    {
        
    }

    public void Interact(PlayerState_Player interacter)
    {
        StoryTracker.Instance.TriggerStoryEvent(eventToInteractWith.StoryEventID);
    }

    // Start is called before the first frame update
    void Start()
    {
        eventToInteractWith = GetComponent<StoryEvent>();
    }

}
