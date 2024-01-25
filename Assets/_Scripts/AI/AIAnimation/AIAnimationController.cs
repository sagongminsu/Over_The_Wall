using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AIState
{
    Idle,
    Walking,
    Attacking,
    Fleeing
}

public class AIAnimationController : MonoBehaviour
{
    public Transform player; // �÷��̾��� ��ġ
    //public PlayerController playerController; // �÷��̾� ��Ʈ�ѷ�
    private NavMeshAgent agent; // �׺�޽� ������Ʈ
    private Animator animator; // �ִϸ����� ������Ʈ
    private AIState state = AIState.Idle; // AI�� �ʱ� ���´� ���

    void Start()
    {
        // ������Ʈ�� �����ɴϴ�
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // �÷��̾���� �Ÿ��� ����մϴ�
        float distance = Vector3.Distance(transform.position, player.position);

        ////�÷��̾���� �Ÿ��� ���� ���¸� �����մϴ�
        //if (distance < 5 && playerController.isAttacking) // �÷��̾ ���� ���� ���
        //{
        //    state = AIState.Attacking;
        //}
        //else if (distance < 10)
        //{
        //    state = AIState.Fleeing;
        //}
        //else
        //{
        //    state = AIState.Walking;
        //}

        // ���¿� ���� �ൿ�� �����մϴ�
        switch (state)
        {
            case AIState.Idle:
                agent.isStopped = true;
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsAttacking", false);
                animator.SetBool("IsFleeing", false);
                break;
            case AIState.Walking:
                agent.isStopped = false;
                agent.SetDestination(player.position);
                animator.SetBool("IsWalking", true);
                animator.SetBool("IsAttacking", false);
                animator.SetBool("IsFleeing", false);
                break;
            case AIState.Attacking:
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsAttacking", true);
                animator.SetBool("IsFleeing", false);
                break;
            case AIState.Fleeing:
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsAttacking", false);
                animator.SetBool("IsFleeing", true);
                // �������� ������ ���⿡ �����մϴ�
                break;
        }
    }
}

