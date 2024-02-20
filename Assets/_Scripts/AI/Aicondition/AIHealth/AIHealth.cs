using System;
using UnityEngine;
using UnityEngine.AI;

public class AIHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int health;
    public event Action OnDie;

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private AiStateMachine aiStateMachine; // AI 상태 머신 참조

    public bool IsDead => health <= 0;

    private void Start()
    {
        health = maxHealth;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        Ai aiComponent = GetComponent<Ai>();
        if (aiComponent != null)
        {
            aiStateMachine = aiComponent.StateMachine; // 상태 머신 참조 초기화
        }
        else
        {
            Debug.LogError("AI 컴포넌트를 찾을 수 없습니다!", this);
        }
    }

    public void TakeDamage(int damage)
    {
        if (IsDead) return;
        health = Mathf.Max(health - damage, 0);
        Debug.Log($"Current Health: {health}");

        if (IsDead)
        {
            OnDie?.Invoke();
            // AI가 죽었을 때의 추가 로직을 여기에 구현합니다.
            if (navMeshAgent != null)
                navMeshAgent.enabled = false;
            if (animator != null)
                animator.SetTrigger("Die");
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("PlayerWeapon")) // 플레이어 무기와 충돌 시
        {
            // AI에게 데미지 적용
            TakeDamage(aiStateMachine.Ai.Data.Damage);
        }
    }
}
