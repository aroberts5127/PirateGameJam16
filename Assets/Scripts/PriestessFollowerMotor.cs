using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PriestessFollowerMotor : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _agent;
     private PlayerState_Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerState_Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _agent.SetDestination(player.GetFollowerTarget().position);
    }
}
