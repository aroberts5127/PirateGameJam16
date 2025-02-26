using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState {IDLE, PATROL, HUNTING}
public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private float movementRadius;
    [SerializeField]
    private EnemyState currentState;
    [SerializeField]
    private WaypointGroup waypointSet;

    private Transform _target;
    private Transform _playerTarget;

    [SerializeField]
    private int targetIDModifier = 1;
    private float attackTimer;
    private int targetID;

    [SerializeField]
    private Animator _animator;

    private void Start()
    {; 
        currentState = waypointSet == null? EnemyState.IDLE : EnemyState.PATROL;
        agent = GetComponentInParent<NavMeshAgent>();
        targetID = 0;
        //_target = waypointSet.GetWaypoints()[targetID].transform;
        //agent.SetDestination(_target.position);
        this.GetComponent<EnemyDetection>().playerSeenAction += StartHuntListener;
        
    }

    private void Update()
    {
        _animator.SetBool("IsMoving", agent.velocity.magnitude > 0.0f);
        if (currentState == EnemyState.PATROL)
        {

            if (Vector3.Distance(agent.transform.position, _target.position) < 0.1f)
            {
                //Debug.Log("Choosing New Target)");
                ChooseNewTarget();               
                //Works - ToDo: Make enemy stop at each point for a bit, and look around before continuing.
            }         
        }
        if (currentState == EnemyState.HUNTING)
        {
            if(Vector3.Distance(agent.transform.position, _playerTarget.position) < GetComponent<EnemyDetection>().raycastDistance * 1.5f)
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
        if (currentState == EnemyState.HUNTING)
            return;
        this.GetComponent<EnemyDetection>().playerSeenAction -= StartHuntListener;
        this.GetComponent<EnemyDetection>().playerLostAction += PlayerLostListener;
        currentState = EnemyState.HUNTING; 
        _animator.SetBool("IsRunning", true);
        //agent.isStopped = true;
        _playerTarget = player;

    }

    void PlayerLostListener()
    {
        if (currentState != EnemyState.HUNTING)
            return;
        this.GetComponent<EnemyDetection>().playerLostAction -= PlayerLostListener;
        this.GetComponent<EnemyDetection>().playerSeenAction += StartHuntListener;
        currentState = waypointSet == null ? EnemyState.IDLE : EnemyState.PATROL;
        _playerTarget = null;
        _animator.SetBool("IsRunning", false);
    }


    private void Hunt()
    {
        //Debug.Log("Hunting");
        agent.SetDestination(_playerTarget.position);
        
    }

    private void Attack()
    {

    }

    private void OnDestroy()
    {
        this.GetComponent<EnemyDetection>().playerLostAction -= PlayerLostListener;
        this.GetComponent<EnemyDetection>().playerSeenAction -= StartHuntListener;
    }

}
