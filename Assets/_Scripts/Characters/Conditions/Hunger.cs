using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hunger : MonoBehaviour
{
    public Image hungerIcon; // 배고픔 아이콘에 대한 참조
    private float hunger = 100.0f; // 초기 배고픔 수치
    private bool isBlinking = false; // 아이콘 깜빡임 상태
    private float hungerDecreaseRate = 0.5f; // 배고픔 감소율

    void Start()
    {
        // 게임 시작 시 UI 이미지 숨기기
        hungerIcon.enabled = false;
    }

    void Update()
    {
        // 일정 시간마다 헝거 수치 감소
        DecreaseHunger(hungerDecreaseRate * Time.deltaTime);

        // 배고픔 수치가 20% 이하이고 아직 깜빡이지 않는 상태
        if (hunger <= 20.0f && !isBlinking)
        {
            StartCoroutine(BlinkIcon());
        }
    }

    IEnumerator BlinkIcon()
    {
        isBlinking = true;
        if (hunger <= 30.0f)
        {
            hungerIcon.enabled = !hungerIcon.enabled;
            yield return new WaitForSeconds(1.0f); // 1.0초마다 깜빡임
        }
 
        hungerIcon.enabled = true; // 배고픔가 30% 이상이면 깜빡임 중지
        isBlinking = false;
    }

    // 헝거 감소 함수
    public void DecreaseHunger(float amount)
    {
        hunger -= amount;
        if (hunger < 0) hunger = 0;
    }

    // 헝거 회복 함수
    public void IncreaseHunger(float amount)
    {
        hunger += amount;
        if (hunger > 100) hunger = 100;
    }
}
