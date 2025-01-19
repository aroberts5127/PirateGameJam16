using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerInput : MonoBehaviour
{
    private Vector3 _curMoveVector;
    private PlayerMotor _motor;
    private PlayerState_Base _state;



    void Start()
    {
        _motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        _curMoveVector.x = Input.GetAxis("Horizontal");
        _curMoveVector.z = Input.GetAxis("Vertical");

        if (_curMoveVector != Vector3.zero)
        {
            _motor.MovePlayer(_curMoveVector);
        }

        _motor.SetSprinting(Input.GetKey(KeyCode.LeftShift));

        if (Input.GetKeyDown(KeyCode.Z))
        {
            transform.GetComponentInParent<PlayerState_Base>().PerformAction();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log((transform.GetComponentInParent<iDepossess>()) == null);
        }
    }
}
