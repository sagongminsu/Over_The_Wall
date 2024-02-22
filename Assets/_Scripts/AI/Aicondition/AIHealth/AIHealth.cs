using System;
using UnityEngine;
using UnityEngine.AI;


public class AIHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private Animator animator; // 애니메이터 컴포넌트에 대한 참조
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

        // 피격 애니메이션 재생
        if (animator && damage > 0)
        {
            animator.SetTrigger(hitTrigger);
        }

        if (IsDead)
        {
            OnDie?.Invoke();
        }
    }

    // 사망 처리 로직
    private void HandleDeath()
    {
        // AI 비활성화 및 사망 애니메이션 재생 등의 로직
        gameObject.SetActive(false);
    }
}
