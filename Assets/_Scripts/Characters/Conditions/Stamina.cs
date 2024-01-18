using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public Image staminaIcon; // ���׹̳� �����ܿ� ���� ����
    private float stamina = 100.0f; // �ʱ� ���׹̳� ��
    private float maxStamina = 100.0f; // �ִ� ���׹̳� ��
    private Animator animator;
    private bool isBlinking = false;

    public float recoveryRate = 1.0f;


    void Start()
    {
        staminaIcon.enabled = false; // ���׹̳� �������� �׻� �Ⱥ��̰� ����
        animator = GetComponent<Animator>();
       
        UpdateStaminaUI(); // UI ������Ʈ
    }

    void Update()
    {



        bool isRunning = animator.GetBool("Run");

        if (isRunning && stamina > 0)
        {
            
            stamina -= 1 * Time.deltaTime; // �޸��� ���� �� ���׹̳��� 1�� ����
            
        }
        else if (!isRunning && stamina < maxStamina)
        {
            // �޸��� �ʴ� ���� ���׹̳� ȸ��
            stamina += recoveryRate * Time.deltaTime;
            stamina = Mathf.Min(stamina, maxStamina); // �ִ�ġ�� ���� �ʵ��� ��
        }



        // ���׹̳��� 30% ������ ���� ������ ȿ���� ����
        if (stamina <= 30.0f && !isBlinking)
        {
            StartCoroutine(BlinkIcon());
        }
        // ���׹̳��� 30% �̻� ȸ���Ǹ� �������� �ߴ�
        else if (stamina > 30.0f && isBlinking)
        {
            StopCoroutine(BlinkIcon());
            isBlinking = false;
            staminaIcon.enabled = true; // ���׹̳� �������� �ٽ� Ȱ��ȭ
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
            yield return new WaitForSeconds(1.0f); // 1.0�ʸ��� ������
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
