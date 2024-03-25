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
    private AiStateMachine aiStateMachine; // AI ���� �ӽ� ����

    public bool IsDead => health <= 0;
    private void Awake()
    {
        health = maxHealth;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // ��� �̺�Ʈ�� �޼��带 �����մϴ�.
        OnDie += HandleDeath;
    }

    private void Start()
    {

        Ai aiComponent = GetComponent<Ai>();
        if (aiComponent != null)
        {
            aiStateMachine = aiComponent.StateMachine; // ���� �ӽ� ���� �ʱ�ȭ
        }
        else
        {
            Debug.LogError("AI ������Ʈ�� ã�� �� �����ϴ�!", this);
        }
    }
    private void OnDestroy()
    {
        // ������Ʈ�� �ı��� �� �̺�Ʈ ������ �����մϴ�.
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
            // AI�� ����ߴٸ� ��� ó���� �����մϴ�.
            OnDie?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("PlayerWeapon")) // �÷��̾� ����� �浹 ��
        {
            // AI���� ������ ����
            TakeDamage(aiStateMachine.Ai.Data.Damage);
        }
    }

    private void HandleDeath()
    {
        gameObject.SetActive(false);
    }
}