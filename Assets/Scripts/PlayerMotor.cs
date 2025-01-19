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

    private float raycastDistance = 1f;
    [SerializeField]
    private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, groundLayer))
        {
            Vector3 slopeNormal = hit.normal;
            float slopeAngle = Vector3.Angle(slopeNormal, Vector3.up);
            Debug.Log(slopeAngle);
            // Adjust vertical position based on the slope angle and movement
            if (slopeAngle > 5f)

            {
                Vector3 newPosition = transform.parent.transform.position;
                newPosition.y = hit.point.y + (transform.localScale.y / 2f); // Adjust based on your object's height
                transform.parent.transform.position = newPosition;
            }

        }

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
