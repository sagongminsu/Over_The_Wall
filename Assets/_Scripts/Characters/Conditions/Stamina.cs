using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public Image staminaIcon; // 스테미나 아이콘에 대한 참조
    private float stamina = 100.0f; // 초기 스테미나 값
    private float maxStamina = 100.0f; // 최대 스테미나 값
    private Animator animator;
    private bool isBlinking = false;

    void Start()
    {
        staminaIcon.enabled = false;
        animator = GetComponent<Animator>();
        stamina = maxStamina; // 스테미나 초기화
        UpdateStaminaUI(); // UI 업데이트
    }

    void Update()
    {
        // 스테미나 회복 로직
        // 예: stamina += 회복량 * Time.deltaTime;
        stamina += Time.deltaTime;
        UpdateStaminaUI();
        if (animator.GetBool("isRunning") && stamina > 0)
        {
            stamina -= 1 * Time.deltaTime; // 스테미나 1씩 감소
            UpdateStaminaUI();
        }
        if (stamina <= 20.0f && !isBlinking)
        {
            StartCoroutine(BlinkIcon());
        }
    }
    IEnumerator BlinkIcon()
    {
        isBlinking = true;
        if (stamina <= 30.0f)
        {
            staminaIcon.enabled = !staminaIcon.enabled;
            yield return new WaitForSeconds(1.0f); // 1.0초마다 깜빡임
        }

        staminaIcon.enabled = true; // 스테미너가 30% 이상이면 깜빡임 중지
        isBlinking = false;
    }

    public void UseStamina(float amount)
    {
        stamina -= amount;
        if (stamina < 0) stamina = 0;
        UpdateStaminaUI();
    }

    private void UpdateStaminaUI()
    {
        staminaIcon.fillAmount = stamina / maxStamina;
    }
}
