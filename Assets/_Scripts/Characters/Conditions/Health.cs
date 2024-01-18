using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthIcon; // ü�� �����ܿ� ���� ����
    private float health = 100.0f;
    private bool isBlinking = false;
    [SerializeField] private DamageIndicator damageIndicator;

    void Start()
    {
        // ���� ���� �� UI �̹��� �����
        healthIcon.enabled = false;
    }

    void Update()
    {
        // ü���� 30% �����̰� ���� �������� �ʴ� ���¶��
        if (health <= 30.0f && !isBlinking)
        {
            StartCoroutine(BlinkIcon());
        }
    }

    IEnumerator BlinkIcon()
    {
        isBlinking = true;
        while (health <= 30.0f)
        {
            healthIcon.enabled = !healthIcon.enabled;
            yield return new WaitForSeconds(1.0f); // 1.0�ʸ��� ������
        }
        healthIcon.enabled = true; // ü���� 30% �̻��̸� ������ ����
        isBlinking = false;
    }


    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            health = 0;
            healthIcon.fillAmount = 0;
            Die(); // ���� ó�� �޼��� ȣ��
        }
        else
        {
            healthIcon.fillAmount = health / 100.0f;
        }

        if (damageIndicator != null)
        {
            damageIndicator.Flash();
        }
    }

    private void Die()
    {
        Debug.Log("�÷��̾ �׾����ϴ�!");
    }
}
