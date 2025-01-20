using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState { PATROL, HUNTING}
public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private float movementRadius;
    private EnemyState currentState;
    [SerializeField]
    private WaypointGroup waypointSet;

    private Transform _target;
    private Transform _playerTarget;

    [SerializeField]
    private int targetIDModifier = 1;
    private float attackTimer;
    private int targetID;

    private void Start()
    {; 
        currentState = EnemyState.PATROL;
        agent = GetComponentInParent<NavMeshAgent>();
        targetID = 0;
        _target = waypointSet.GetWaypoints()[targetID].transform;
        agent.SetDestination(_target.position);
        this.GetComponent<EnemyDetection>().playerSeenAction += StartHuntListener;
    }

    private void Update()
    {
        if (currentState == EnemyState.PATROL)
        {
            if (Vector3.Distance(agent.transform.position, _target.position) < 0.1f)
            {
                Debug.Log("Choosing New Target)");
                ChooseNewTarget();               
                //Works - ToDo: Make enemy stop at each point for a bit, and look around before continuing.
            }         
        }
        if (currentState == EnemyState.HUNTING)
        {
            Hunt();
        }
        
    }

    private void ChooseNewTarget()
    {
        if (_target.GetComponent<Waypoint>().ID + targetIDModifier > waypointSet.GetWaypoints().Count-1 || _target.GetComponent<Waypoint>().ID + targetIDModifier < 0)
            targetIDModifier = targetIDModifier * -1;
        targetID = _target.GetComponent<Waypoint>().ID + targetIDModifier;
        _target = waypointSet.GetWaypointWithID(targetID).transform;
        agent.SetDestination(_target.position);
    }

    void StartHuntListener(Transform player)
    {
        currentState = EnemyState.HUNTING;
        agent.isStopped = true;
        _playerTarget = player;
    }


    private void Hunt()
    {
        Debug.Log("Hunting");
    }

    private void Attack()
    {

    }


}
