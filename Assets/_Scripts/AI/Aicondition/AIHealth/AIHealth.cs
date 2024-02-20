using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIHealth : CharacterHealth
{

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private AiStateMachine aiStateMachine; // AI ���� �ӽ� ����

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        Ai aiComponent = GetComponent<Ai>();
        aiStateMachine = aiComponent.StateMachine; // ���� �ӽ� ���� �ʱ�ȭ
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("PlayerWeapon")) // �÷��̾� ����� �浹 ��
        {
            IDamagable damagable = collider.gameObject.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.TakeDamage(aiStateMachine.Ai.Data.Damage); // AI���� ���������
            }
        }
    }
    //public void OnDie()
    //{
    //    // AI�� �׾��� ���� ������ �����մϴ�.
    //    if (navMeshAgent != null)
    //        navMeshAgent.enabled = false;
    //    if (animator != null)
    //        animator.SetTrigger("Die");

    //}

}

