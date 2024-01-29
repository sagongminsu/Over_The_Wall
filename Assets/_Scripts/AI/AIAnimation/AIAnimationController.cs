using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class NPCAnimationController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    public Transform target;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (target != null)
        {
            navMeshAgent.SetDestination(target.position);
            // 이동 속도에 따라 애니메이션 상태를 업데이트합니다.
            float speed = navMeshAgent.velocity.magnitude;
            animator.SetFloat("Speed", speed); // "Speed"는 애니메이터 파라미터의 이름입니다.
        }
    }
}


