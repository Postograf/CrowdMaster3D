using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ChaseState : EnemyState
{
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        _agent.enabled = true;
        Animator.SetTrigger("run");
    }

    private void OnDisable()
    {
        _agent.enabled = false;
    }

    private void Update()
    {
        _agent.SetDestination(Player.transform.position);
    }
}
