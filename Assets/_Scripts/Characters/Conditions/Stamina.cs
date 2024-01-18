using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public Image staminaIcon; // 스테미나 아이콘에 대한 참조
    private float stamina = 100.0f; // 초기 스테미나 값
    private float maxStamina = 100.0f; // 최대 스테미나 값
    private Animator animator;
    private bool isBlinking = false;

    public float recoveryRate = 1.0f;


    void Start()
    {
        staminaIcon.enabled = false; // 스테미나 아이콘을 항상 안보이게 설정
        animator = GetComponent<Animator>();
       
        UpdateStaminaUI(); // UI 업데이트
    }

    void Update()
    {



        bool isRunning = animator.GetBool("Run");

        if (isRunning && stamina > 0)
        {
            
            stamina -= 1 * Time.deltaTime; // 달리고 있을 때 스테미나를 1씩 감소
            
        }
        else if (!isRunning && stamina < maxStamina)
        {
            // 달리지 않는 동안 스테미나 회복
            stamina += recoveryRate * Time.deltaTime;
            stamina = Mathf.Min(stamina, maxStamina); // 최대치를 넘지 않도록 함
        }



        // 스테미나가 30% 이하일 때만 깜빡임 효과를 시작
        if (stamina <= 30.0f && !isBlinking)
        {
            StartCoroutine(BlinkIcon());
        }
        // 스테미나가 30% 이상 회복되면 깜빡임을 중단
        else if (stamina > 30.0f && isBlinking)
        {
            StopCoroutine(BlinkIcon());
            isBlinking = false;
            staminaIcon.enabled = true; // 스테미나 아이콘을 다시 활성화
        }
        stamina = Mathf.Clamp(stamina, 0, maxStamina);

        UpdateStaminaUI();

    }

    IEnumerator BlinkIcon()
    {
        isBlinking = true;
        while (stamina <= 30.0f)
        {
            staminaIcon.enabled = !staminaIcon.enabled;
            yield return new WaitForSeconds(1.0f); // 1.0초마다 깜빡임
        }
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
