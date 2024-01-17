using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthIcon; // 체력 아이콘에 대한 참조
    private float health = 100.0f;
    private bool isBlinking = false;

    void Start()
    {
        // 게임 시작 시 UI 이미지 숨기기
        healthIcon.enabled = false;
    }

    void Update()
    {
        // 체력이 20% 이하이고 아직 깜빡이지 않는 상태라면
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
            yield return new WaitForSeconds(0.5f); // 0.5초마다 깜빡임
        }
        healthIcon.enabled = true; // 체력이 20% 이상이면 깜빡임 중지
        isBlinking = false;
    }


    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health < 0) health = 0;
    }
}
