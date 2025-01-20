using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField]
    public float raycastDistance = 5.0f;
    [SerializeField]
    private LayerMask targetMask;
    [SerializeField]
    [Range(0,360)]
    public float viewAngle;

    public Transform playerRef;

    public bool canSeePlayer;

    public event Action<Transform> playerSeenAction;


    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(FieldOfViewRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator FieldOfViewRoutine()
    {
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true)
        {
            FieldOfViewCheck();
            yield return wait;
        }
    }


    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, raycastDistance, targetMask);

        if (rangeChecks.Length > 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < viewAngle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                canSeePlayer = true;
                SeesPlayer();
            }
            else
                canSeePlayer = false;
        }
        else
        {
            canSeePlayer = false;
        }
    }

    public void SeesPlayer()
    {
        playerSeenAction.Invoke(playerRef);
    }
}
