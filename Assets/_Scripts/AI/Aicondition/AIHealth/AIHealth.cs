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
    private void Awake()
    {
        health = maxHealth;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // 사망 이벤트에 메서드를 연결합니다.
        OnDie += HandleDeath;
    }

    private void Start()
    {

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
    private void OnDestroy()
    {
        // 컴포넌트가 파괴될 때 이벤트 연결을 해제합니다.
        OnDie -= HandleDeath;
    }
    public void TakeDamage(int damage)
    {
        if (IsDead) return;
        health = Mathf.Max(health - damage, 0);
        Debug.Log($"Current Health: {health}");

        if (!IsDead)
        {
            animator.SetTrigger("Hit");
            var aiStateMachine = GetComponent<Ai>().StateMachine;
            aiStateMachine.ChangeState(new AiHitState(aiStateMachine));
        }
        else
        {
            // AI가 사망했다면 사망 처리를 수행합니다.
            OnDie?.Invoke();
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

    private void HandleDeath()
    {
        gameObject.SetActive(false);
    }
}