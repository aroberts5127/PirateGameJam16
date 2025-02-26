using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PriestessFollowerMotor : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _agent;
    private PlayerState_Player player;
    [SerializeField]
    private Animator _animator;

    private bool _isSprinting;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerState_Player>();
    }

    private void Update()
    {
        _isSprinting = Input.GetKey(KeyCode.LeftShift);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _agent.SetDestination(player.GetFollowerTarget().position);
        _animator.SetFloat("isRunning", _agent.velocity.magnitude);
        _animator.SetBool("isSprinting", _isSprinting);
    }

    //Need a way to make sure the Princess Sprints when the Hero Sprints and walks when the hero walks

}
