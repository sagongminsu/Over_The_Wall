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
        // 컴포넌트를 가져옵니다.
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // 이동 속도에 따라 애니메이션을 변경합니다.
        float speed = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("Speed", speed);
    }
}


