using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int damage = 10; // 대미지 값 설정
    [SerializeField] private Collider weaponCollider; // 무기의 Collider

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Ai")) // AI와 충돌했는지 확인
        {
            
            var healthComponent = other.GetComponent<AIHealth>(); // AIHealth 컴포넌트 참조
            Debug.Log($"[Weapon] 플레이어 {other.name}에게 {damage} 대미지 적용.");
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(damage); // 대미지 적용
            }
        }
    }

    // Collider 활성화/비활성화
    public void ToggleColliders(bool state)
    {
        weaponCollider.enabled = state;
    }
    
}
