using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIHealth : MonoBehaviour
{
    public int maxHealth = 100; // AI의 최대 체력을 설정
    private int currentHealth; // AI의 현재 체력

    private NavMeshAgent navMeshAgent; // Nav Mesh Agent 참조를 저장합니다.
    private Animator animator; // Animator 참조를 저장합니다.

    void Start()
    {
        currentHealth = maxHealth;
        navMeshAgent = GetComponent<NavMeshAgent>(); // Nav Mesh Agent 컴포넌트를 가져옵니다.
        animator = GetComponent<Animator>(); // Animator 컴포넌트를 가져옵니다.
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // 피해량만큼 체력을 감소시킵니다.
        if (currentHealth <= 0)
        {
            Die(); // 체력이 0 이하가 되면 Die 함수를 호출합니다.
        }
    }

    public void Heal(int healingAmount)
    {
        currentHealth += healingAmount; // 회복량
        currentHealth = Mathf.Min(currentHealth, maxHealth); // 체력이 최대 체력을 넘지 않도록
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerWeapon"))
        {
           //collision.gameObject.GetComponent<PlayerWeapon>().SetDamage();
            //TakeDamage((int)collision.gameObject.GetComponent<PlayerWeapon>().WeaponDamage);
            
           
        }
    }
    void Die()
    {
        // AI가 죽었을 때의 로직을 구현합니다.
        if (navMeshAgent != null)
        {
            navMeshAgent.enabled = false; // Nav Mesh Agent를 비활성화합니다.
        }

        if (animator != null)
        {
            animator.enabled = false; // Animator를 비활성화합니다.
        }

    }


}

