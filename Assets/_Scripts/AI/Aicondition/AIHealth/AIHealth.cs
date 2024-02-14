using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIHealth : CharacterHealth
{

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private AiStateMachine aiStateMachine; // AI 상태 머신 참조

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        Ai aiComponent = GetComponent<Ai>();
        aiStateMachine = aiComponent.StateMachine; // 상태 머신 참조 초기화
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("PlayerWeapon")) // 플레이어 무기와 충돌 시
        {
            IDamagable damagable = collider.gameObject.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.TakeDamage(aiStateMachine.Ai.Data.Damage); // AI의 대미지를 플레이어에 적용
            }
        }
    }
    //public void OnDie()
    //{
    //    // AI가 죽었을 때의 로직을 구현합니다.
    //    if (navMeshAgent != null)
    //        navMeshAgent.enabled = false;
    //    if (animator != null)
    //        animator.SetTrigger("Die");

    //}

}

