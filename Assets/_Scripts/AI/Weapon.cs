using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private Collider myCollider;

    private int damage;
    private float knockback;

    private List<Collider> alreadyColliderWith = new List<Collider>();

    private void OnEnable()
    {
        alreadyColliderWith.Clear();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider == myCollider) return;
        if (!collider.CompareTag("Ai")) return; // "" �±׸� ���� ��ü���� ����� ����
        if (alreadyColliderWith.Contains(collider)) return;

        alreadyColliderWith.Add(collider);

        // Ai���� ����� ����
        if (collider.TryGetComponent(out AIHealth health))
        {
            health.TakeDamage(damage);
            Debug.Log($"[Weapon] �÷��̾� {collider.name}���� {damage} ����� ����.");
        }

        // Ai���� �˹� ����
        if (collider.TryGetComponent(out ForceReceiver forceReceiver))
        {
            Vector3 direction = (collider.transform.position - myCollider.transform.position).normalized;
            forceReceiver.AddForce(direction * knockback);
           
        }
    }

    // Collider Ȱ��ȭ/��Ȱ��ȭ
    public void ToggleColliders(bool state)
    {
        myCollider.enabled = state;
    }
    
}
