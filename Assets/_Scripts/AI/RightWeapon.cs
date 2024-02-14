using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWeapon : MonoBehaviour
{
    [SerializeField] private Collider myCollider;

    private int damage;
    private float knockback;

    private List<Collider> alreadyColliderWith = new List<Collider>();

    private void OnEnable()
    {
        alreadyColliderWith.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == myCollider) return;
        if (!other.CompareTag("Player")) return; // "Player" �±׸� ���� ��ü���� ����� ����
        if (alreadyColliderWith.Contains(other)) return;

        alreadyColliderWith.Add(other);

        // �÷��̾�� ����� ����
        if (other.TryGetComponent(out PlayerConditions health))
        {
            health.TakeDamage(damage);
            Debug.Log($"[Weapon] �÷��̾� {other.name}���� {damage} ����� ����.");
        }

        // �÷��̾�� �˹� ����
        if (other.TryGetComponent(out ForceReceiver forceReceiver))
        {
            Vector3 direction = (other.transform.position - myCollider.transform.position).normalized;
            forceReceiver.AddForce(direction * knockback);
            Debug.Log($"[Weapon] �÷��̾� {other.name}���� �˹� ����: ���� {direction}, �� {knockback}");
        }
    }

    public void SetAttack(int damage, float knockback)
    {
        this.damage = damage;
        this.knockback = knockback;
    }

}
