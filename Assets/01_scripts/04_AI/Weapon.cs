using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private Collider aCollider;

    private int damage = 10;
    

    private List<Collider> alreadyColliderWith = new List<Collider>();

    private void OnEnable()
    {
        alreadyColliderWith.Clear();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider == aCollider) return;
        if (!collider.CompareTag("Ai")) return; // "" �±׸� ���� ��ü���� ����� ����
        if (alreadyColliderWith.Contains(collider)) return;

        alreadyColliderWith.Add(collider);

        // Ai���� ����� ����
        if (collider.TryGetComponent(out AIHealth health))
        {
            health.TakeDamage(damage);
            Debug.Log($"[Weapon] �÷��̾� {collider.name}���� {damage} ����� ����");
        }


    }

    // Collider Ȱ��ȭ/��Ȱ��ȭ
    public void ToggleColliders(bool state)
    {
        aCollider.enabled = state;
    }
    
}
