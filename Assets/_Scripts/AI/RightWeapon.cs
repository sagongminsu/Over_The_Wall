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
        if (!other.CompareTag("Player")) return; // "Player" 태그를 가진 객체에만 대미지 적용
        if (alreadyColliderWith.Contains(other)) return;

        alreadyColliderWith.Add(other);

        // 플레이어에게 대미지 적용
        if (other.TryGetComponent(out PlayerConditions health))
        {
            health.TakeDamage(damage);
            Debug.Log($"[Weapon] 플레이어 {other.name}에게 {damage} 대미지 적용.");
        }

        // 플레이어에게 넉백 적용
        if (other.TryGetComponent(out ForceReceiver forceReceiver))
        {
            Vector3 direction = (other.transform.position - myCollider.transform.position).normalized;
            forceReceiver.AddForce(direction * knockback);
            Debug.Log($"[Weapon] 플레이어 {other.name}에게 넉백 적용: 방향 {direction}, 힘 {knockback}");
        }
    }

    public void SetAttack(int damage, float knockback)
    {
        this.damage = damage;
        this.knockback = knockback;
    }

}
