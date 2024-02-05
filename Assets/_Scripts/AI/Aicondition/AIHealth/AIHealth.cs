using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIHealth : MonoBehaviour
{
    public int maxHealth = 100; // AI�� �ִ� ü���� ����
    private int currentHealth; // AI�� ���� ü��

    private NavMeshAgent navMeshAgent; // Nav Mesh Agent ������ �����մϴ�.
    private Animator animator; // Animator ������ �����մϴ�.

    void Start()
    {
        currentHealth = maxHealth;
        navMeshAgent = GetComponent<NavMeshAgent>(); // Nav Mesh Agent ������Ʈ�� �����ɴϴ�.
        animator = GetComponent<Animator>(); // Animator ������Ʈ�� �����ɴϴ�.
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // ���ط���ŭ ü���� ���ҽ�ŵ�ϴ�.
        if (currentHealth <= 0)
        {
            Die(); // ü���� 0 ���ϰ� �Ǹ� Die �Լ��� ȣ���մϴ�.
        }
    }

    public void Heal(int healingAmount)
    {
        currentHealth += healingAmount; // ȸ����
        currentHealth = Mathf.Min(currentHealth, maxHealth); // ü���� �ִ� ü���� ���� �ʵ���
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
        // AI�� �׾��� ���� ������ �����մϴ�.
        if (navMeshAgent != null)
        {
            navMeshAgent.enabled = false; // Nav Mesh Agent�� ��Ȱ��ȭ�մϴ�.
        }

        if (animator != null)
        {
            animator.enabled = false; // Animator�� ��Ȱ��ȭ�մϴ�.
        }

    }


}

