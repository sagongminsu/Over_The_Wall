using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAnimationController : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;

    void Start()
    {
        // ������Ʈ�� �����ɴϴ�.
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // �̵� �ӵ��� ���� �ִϸ��̼��� �����մϴ�.
        float speed = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("Speed", speed);
    }
}


