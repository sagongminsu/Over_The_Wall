using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private AiStateMachine aiStateMachine; // AI ���� �ӽ� ����

    void Start()
    {
        currentHealth = maxHealth;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        aiStateMachine = GetComponent<AiStateMachine>(); // ���� �ӽ� ���� �ʱ�ȭ
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
           
            aiStateMachine.OnAttacked();
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        //if (collision.gameObject.CompareTag("PlayerWeapon"))
        //{
        //   //collision.gameObject.GetComponent<PlayerWeapon>().SetDamage();
        //    //TakeDamage((int)collision.gameObject.GetComponent<PlayerWeapon>().WeaponDamage);
 
        //}

    }
    void Die()
    {
        // AI�� �׾��� ���� ������ �����մϴ�.
        if (navMeshAgent != null)
            navMeshAgent.enabled = false;
        if (animator != null)
            animator.SetTrigger("Die");

    }

}

