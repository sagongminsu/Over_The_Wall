using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWeapon : MonoBehaviour
{
    [SerializeField] private Collider myCollider;

    private int damage = 10;
    private float knockback;

    private List<Collider> alreadyCollidedWith = new List<Collider>();

    private void OnEnable()
    {
        ResetCollisions();
    }

    // 새로운 공격이 시작될 때 호출될 메소드
    public void ResetCollisions()
    {
        alreadyCollidedWith.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == myCollider) return;
        if (alreadyCollidedWith.Contains(other)) return;

        alreadyCollidedWith.Add(other);

        if (other.TryGetComponent(out PlayerConditions health))
        {
            health.TakeDamage(damage);
        }

        if (other.TryGetComponent(out ForceReceiver forceReceiver))
        {
            Vector3 direction = (other.transform.position - myCollider.transform.position).normalized;
            forceReceiver.AddForce(direction * knockback);
        }


    }

    public void SetAttack(int damage, float knockback)
    {

        this.damage = damage;
        this.knockback = knockback;
    }
}
