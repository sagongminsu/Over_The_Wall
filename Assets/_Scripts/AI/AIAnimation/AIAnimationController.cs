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
    public Transform player; // 플레이어의 위치
    //public PlayerController playerController; // 플레이어 컨트롤러
    private NavMeshAgent agent; // 네비메쉬 에이전트
    private Animator animator; // 애니메이터 컴포넌트
    private AIState state = AIState.Idle; // AI의 초기 상태는 대기

    void Start()
    {
        // 컴포넌트를 가져옵니다
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 플레이어와의 거리를 계산합니다
        float distance = Vector3.Distance(transform.position, player.position);

        ////플레이어와의 거리에 따라 상태를 변경합니다
        //if (distance < 5 && playerController.isAttacking) // 플레이어가 공격 중일 경우
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

        // 상태에 따른 행동을 수행합니다
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
                // 도망가는 로직을 여기에 구현합니다
                break;
        }
    }
}

