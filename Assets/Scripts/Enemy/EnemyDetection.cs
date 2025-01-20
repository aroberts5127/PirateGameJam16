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
    [SerializeField]
    public bool canSeePlayer; 
    [SerializeField]
    private bool lostPlayerTimerActive;
    [SerializeField]
    private float lostPlayerTimer = 0.0f;
    [SerializeField]
    private float lostPlayerActionTime = 3.0f;

    public event Action<Transform> playerSeenAction;
    public event Action playerLostAction;


    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(FieldOfViewRoutine());
        lostPlayerTimerActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (lostPlayerTimerActive)
        {
            lostPlayerTimer += Time.deltaTime;
            if (lostPlayerTimer > lostPlayerActionTime)
            {
                lostPlayerTimer = 0;
                lostPlayerTimerActive = false;
                LostPlayer();
            }
        }
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
                //distanceToTarget is used in the example for a raycast to detect blockers. Will Likely need as the scene grows
                float distanceToTarget = Vector3.Distance(transform.position, target.position); 
                canSeePlayer = true;
                lostPlayerTimerActive = false;
                lostPlayerTimer = 0.0f;
                SeesPlayer();
            }
            else
            {
                if(canSeePlayer)
                    lostPlayerTimerActive = true;
                canSeePlayer = false;
                
                //LostPlayer();
            }
        }
        else
        {
            if(canSeePlayer)
                lostPlayerTimerActive = true;
            canSeePlayer = false;
            
            //LostPlayer();
        }
    }

    public void SeesPlayer()
    {
        playerSeenAction?.Invoke(playerRef);
    }

    public void LostPlayer()
    {
        playerLostAction?.Invoke();
    }

}
