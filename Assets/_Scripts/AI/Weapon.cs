using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private Collider myCollider;

    private int damage = 10;
    private float knockback;

    private List<Collider> alreadyColliderWith = new List<Collider>();

    private void OnEnable()
    {
        alreadyColliderWith.Clear();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider == myCollider) return;
        if (!collider.CompareTag("Ai")) return; // "" 태그를 가진 객체에만 대미지 적용
        if (alreadyColliderWith.Contains(collider)) return;

        alreadyColliderWith.Add(collider);

        // Ai에게 대미지 적용
        if (collider.TryGetComponent(out AIHealth health))
        {
            health.TakeDamage(damage);
            Debug.Log($"[Weapon] 플레이어 {collider.name}에게 {damage} 대미지 적용.");
        }


    }

    // Collider 활성화/비활성화
    public void ToggleColliders(bool state)
    {
        myCollider.enabled = state;
    }
    
}
