using System;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100; 
    private int health; 
    public event Action OnDie; 

    public bool IsDead => health <= 0;

    private void Start()
    {
        health = maxHealth; 
    }

    public void TakeDamage(int damage)
    {
        if (IsDead) return;
        health = Mathf.Max(health - damage, 0);

        if (IsDead)
            OnDie?.Invoke();

        Debug.Log($"Current Health: {health}");
    }
}