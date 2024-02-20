using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeft : MonoBehaviour
{
    [SerializeField] private Collider myCollider;

    private int damage = 10;
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

    private void OnTriggerEnter(Collider collider)
    {
        if (collider == myCollider) return;
        if (!collider.CompareTag("Ai")) return;
        if (alreadyCollidedWith.Contains(collider)) return;

        alreadyCollidedWith.Add(collider);

        // �÷��̾�� ������ �� �˹� ����
        ApplyDamageAndKnockback(collider);
    }

    private void ApplyDamageAndKnockback(Collider target)
    {
        if (target.TryGetComponent(out AIHealth health))
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
