using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public event Action OnDie;

    public bool IsDead => currentHealth == 0;

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private AiStateMachine aiStateMachine; // AI 상태 머신 참조

    void Start()
    {
        currentHealth = maxHealth;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        aiStateMachine = GetComponent<AiStateMachine>(); // 상태 머신 참조 초기화
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth == 0) return;
        currentHealth = Mathf.Max(currentHealth - damage, 0);

        if (currentHealth == 0)
            OnDie?.Invoke();
        else
        {
           
            aiStateMachine.OnAttacked();
        }

        Debug.Log(currentHealth);
    }
    private void OnTriggerEnter(Collider collision)
    {
        //if (collision.gameObject.CompareTag("PlayerWeapon"))
        //{
        //   //collision.gameObject.GetComponent<PlayerWeapon>().SetDamage();
        //    //TakeDamage((int)collision.gameObject.GetComponent<PlayerWeapon>().WeaponDamage);
 
        //}

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

