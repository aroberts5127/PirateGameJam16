using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTracker : MonoBehaviour
{
    public static StoryTracker Instance;

    [SerializeField]
    static Dictionary<int,StoryEvent> eventsDict;
    [SerializeField]
    static private int curStoryIndex;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        LoadStoryEvents();
        curStoryIndex = 1;
    }

    private void LoadStoryEvents()
    {
        eventsDict = new Dictionary<int, StoryEvent>();
        StoryEvent[] storyEventList = GameObject.FindObjectsOfType<StoryEvent>() as StoryEvent[];
        for (int i = 0; i < storyEventList.Length; i++)
            eventsDict.Add(storyEventList[i].StoryEventID, storyEventList[i]);
    }

    public void TriggerStoryEvent(int storyToTrigger)
    {
        if (storyToTrigger != curStoryIndex)
            return;
        eventsDict[storyToTrigger].ResolveStoryEvent();
        curStoryIndex = storyToTrigger + 1;
        //eventsDict[curStoryIndex].StartStoryEvent();
    }
}
