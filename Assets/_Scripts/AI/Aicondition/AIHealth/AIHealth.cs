using System;
using UnityEngine;
using UnityEngine.AI;


public class AIHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private Animator animator; // �ִϸ����� ������Ʈ�� ���� ����
    private int health;
    private static readonly int hitTrigger = Animator.StringToHash("Hit");

    public bool IsDead => health <= 0;
    public event Action OnDie;

    private void Awake()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (IsDead) return;
        health -= damage;
        Debug.Log($"Current Health: {health}");

        // �ǰ� �ִϸ��̼� ���
        if (animator && damage > 0)
        {
            animator.SetTrigger(hitTrigger);
        }

        if (IsDead)
        {
            OnDie?.Invoke();
        }
    }

    // ��� ó�� ����
    private void HandleDeath()
    {
        // AI ��Ȱ��ȭ �� ��� �ִϸ��̼� ��� ���� ����
        gameObject.SetActive(false);
    }
}
