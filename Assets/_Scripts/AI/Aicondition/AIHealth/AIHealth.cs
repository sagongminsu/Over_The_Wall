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


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerWeapon")) 
        {

            
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

