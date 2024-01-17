using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthIcon; // ü�� �����ܿ� ���� ����
    private float health = 100.0f;
    private bool isBlinking = false;

    void Start()
    {
        // ���� ���� �� UI �̹��� �����
        healthIcon.enabled = false;
    }

    void Update()
    {
        // ü���� 20% �����̰� ���� �������� �ʴ� ���¶��
        if (health <= 20.0f && !isBlinking)
        {
            StartCoroutine(BlinkIcon());
        }
    }

    IEnumerator BlinkIcon()
    {
        isBlinking = true;
        while (health <= 20.0f)
        {
            healthIcon.enabled = !healthIcon.enabled;
            yield return new WaitForSeconds(0.5f); // 0.5�ʸ��� ������
        }
        healthIcon.enabled = true; // ü���� 20% �̻��̸� ������ ����
        isBlinking = false;
    }


    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health < 0) health = 0;
    }
}
