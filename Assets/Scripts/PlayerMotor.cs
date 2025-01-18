using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// To Do Block
// Todo #: Add Sprint Feature To Movement
// Todo #:


public class PlayerMotor : MonoBehaviour
{
    


    [SerializeField]
    private float _baseSpeed;
    private float _motorSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovePlayer(Vector3 vec)
    {
        if(vec == Vector3.zero) return;

        Vector3 target = transform.position + vec.normalized;
        transform.parent.position = Vector3.MoveTowards(transform.position, target, _motorSpeed * Time.deltaTime);
        transform.parent.rotation = Quaternion.LookRotation(vec, Vector3.up);
    }

    public void SetSprinting(bool isSprinting)
    {
        _motorSpeed = isSprinting ? _baseSpeed * 1.5f : _baseSpeed;
    }
}
