using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public Image staminaIcon; // ���׹̳� �����ܿ� ���� ����
    private float stamina = 100.0f; // �ʱ� ���׹̳� ��
    private float maxStamina = 100.0f; // �ִ� ���׹̳� ��
    private Animator animator;
    private bool isBlinking = false;

    void Start()
    {
        staminaIcon.enabled = false;
        animator = GetComponent<Animator>();
        stamina = maxStamina; // ���׹̳� �ʱ�ȭ
        UpdateStaminaUI(); // UI ������Ʈ
    }

    void Update()
    {
        // ���׹̳� ȸ�� ����
        // ��: stamina += ȸ���� * Time.deltaTime;
        stamina += Time.deltaTime;
        UpdateStaminaUI();
        if (animator.GetBool("isRunning") && stamina > 0)
        {
            stamina -= 1 * Time.deltaTime; // ���׹̳� 1�� ����
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
            yield return new WaitForSeconds(1.0f); // 1.0�ʸ��� ������
        }

        staminaIcon.enabled = true; // ���׹̳ʰ� 30% �̻��̸� ������ ����
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
