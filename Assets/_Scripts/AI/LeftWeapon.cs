using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWeapon : MonoBehaviour
{
    [SerializeField] private Collider myCollider;

    private int damage;
    private float knockback;

    private List<Collider> alreadyCollidedWith = new List<Collider>();

    private void OnEnable()
    {
        ResetCollisions();
    }

    // ���ο� ������ ���۵� �� ȣ��� �޼ҵ�
    public void ResetCollisions()
    {
        alreadyCollidedWith.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == myCollider) return;
        if (!other.CompareTag("Player")) return;
        if (alreadyCollidedWith.Contains(other)) return;

        alreadyCollidedWith.Add(other);

        // �÷��̾�� ������ �� �˹� ����
        ApplyDamageAndKnockback(other);
    }

    private void ApplyDamageAndKnockback(Collider target)
    {
        if (target.TryGetComponent(out PlayerConditions health))
        {
            health.TakeDamage(damage);
        }

        if (target.TryGetComponent(out ForceReceiver forceReceiver))
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            forceReceiver.AddForce(direction * knockback);
        }
    }

    public void SetAttack(int damage, float knockback)
    {
        this.damage = damage;
        this.knockback = knockback;
    }
}
