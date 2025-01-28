using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


// To Do Block
// Todo #: Add Sprint Feature To Movement
// Todo #:


public class PlayerMotor : MonoBehaviour
{
    


    [SerializeField]
    private float _baseSpeed;
    [SerializeField]
    private float _lookSpeed;
    private float _motorSpeed;
    

    //private float raycastDistance = 0.2f;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    Animator playerAnimator;
    private bool _isInPlayerBody;
    private Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        PlayerState_Player.PlayerInBody += SetPlayerPossessing;
        _isInPlayerBody = true;
        parent = transform.parent.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MovePlayer(Vector3 vec)
    {
        if (vec == Vector3.zero)
        {
            playerAnimator.SetBool("IsMoving", false);
            return;
        }
        if (_isInPlayerBody)
            playerAnimator.SetBool("IsMoving", true);
        else
        {
            playerAnimator.SetBool("IsMoving", false);
        }
        Vector3 target = transform.position + vec.normalized;
        parent.position = Vector3.MoveTowards(transform.position, target, _motorSpeed * Time.deltaTime);
        parent.rotation = Quaternion.SlerpUnclamped(parent.rotation, Quaternion.LookRotation(vec, Vector3.up), _lookSpeed * Time.deltaTime);
    }

    public void SetSprinting(bool isSprinting)
    {
        _motorSpeed = isSprinting ? _baseSpeed * 1.5f : _baseSpeed;
        playerAnimator.SetBool("IsRunning",isSprinting);
    }

    public void SetPlayerPossessing(bool isPlayerPossessed)
    {
        _isInPlayerBody = isPlayerPossessed;
        parent = transform.parent.transform;
    }

}
