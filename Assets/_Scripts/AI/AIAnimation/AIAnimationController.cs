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
            // �̵� �ӵ��� ���� �ִϸ��̼� ���¸� ������Ʈ�մϴ�.
            float speed = navMeshAgent.velocity.magnitude;
            animator.SetFloat("Speed", speed); // "Speed"�� �ִϸ����� �Ķ������ �̸��Դϴ�.
        }
    }
}


