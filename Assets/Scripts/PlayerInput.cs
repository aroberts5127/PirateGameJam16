using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector3 _curMoveVector;
    private PlayerMotor _motor;
    private PlayerStats _stats;
    private PlayerState_Base _state;

    private bool _paused = false;
    

    void Start()
    {
        _motor = GetComponent<PlayerMotor>();
        _stats = GetComponent<PlayerStats>();
        _paused = false;
        CutsceneDialogueController.endDialogueAction += SetInputsOn;
        CutsceneDialogueController.dialogueActive += SetInputsOff;
    }

    void Update()
    {
        if (!_paused)
        {
            _curMoveVector.x = Input.GetAxis("Horizontal");
            _curMoveVector.z = Input.GetAxis("Vertical");

            _motor.MovePlayer(_curMoveVector);

            _motor.SetSprinting(Input.GetKey(KeyCode.LeftShift));

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (_stats.CheckStaminaForActionInput())
                    GetComponentInParent<PlayerState_Base>().PerformAction(_stats);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                //Debug.Log((transform.GetComponentInParent<iDepossess>()) == null);
                if (GetComponentInParent<iDepossess>() != null)
                {
                    transform.GetComponentInParent<iDepossess>().depossess();
                }

            }
        }
        else
        {
            _motor.MovePlayer(Vector3.zero );
        }
        
    }

    public void SetInputsOff()
    {
        _paused = true;
    }
    public void SetInputsOn()
    {
        _paused = false;
    }

    public void OnDestroy()
    {

        CutsceneDialogueController.endDialogueAction -= SetInputsOn;
        CutsceneDialogueController.dialogueActive -= SetInputsOff;

    }
}
