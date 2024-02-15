using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINavigation : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        bool isMoving = navMeshAgent.velocity.magnitude > 0.1f; 


        animator.SetBool("IsWalking", isMoving);

    }
}
