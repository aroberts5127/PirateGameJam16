using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryEvent_FirstToolUse : StoryEvent
{
    [SerializeField]
    private int playerStateActionsNeeded;
    private int playerStateActionsPerformed;
    PlayerState_Base playerState;

    public override void Start()
    {
        base.Start();
        playerState = this.GetComponent<PlayerState_Base>();
        playerState.performActionEvent += PlayerStateActionListener;
    }
    private void PlayerStateActionListener(PlayerState_Base ps)
    {
        playerStateActionsPerformed++;
        if(playerStateActionsPerformed >= playerStateActionsNeeded)
        {
            ps.performActionsCompleted();
            StoryTracker.Instance.TriggerStoryEvent(StoryEventID);
            playerState.performActionEvent -= PlayerStateActionListener;
        }
    }

    private void OnDestroy()
    {
        playerState.performActionEvent -= PlayerStateActionListener;
    }
}
