using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private int damage;
    [SerializeField] private Collider weaponCollider; // ������ Collider

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Ai")) // AI�� �浹�ߴ��� Ȯ��
        {
            
            var healthComponent = other.GetComponent<AIHealth>(); // AIHealth ������Ʈ ����
            Debug.Log($"[Weapon] �÷��̾ Ai���� {damage} ����� ����.");
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(damage); // ����� ����
            }
        }
    }

    // Collider Ȱ��ȭ/��Ȱ��ȭ
    public void ToggleColliders(bool state)
    {
        weaponCollider.enabled = state;
    }
    
}
