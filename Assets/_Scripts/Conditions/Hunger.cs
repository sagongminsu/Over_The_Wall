using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hunger : MonoBehaviour
{
    public Image hungerIcon; // ����� �����ܿ� ���� ����
    private float hunger = 100.0f; // �ʱ� ����� ��ġ
    private bool isBlinking = false; // ������ ������ ����
    private float hungerDecreaseRate = 1.0f; // ����� ������

    void Start()
    {
        // ���� ���� �� UI �̹��� �����
        hungerIcon.enabled = false;
    }

    void Update()
    {
        // ���� �ð����� ��� ��ġ ����
        DecreaseHunger(hungerDecreaseRate * Time.deltaTime);

        // ����� ��ġ�� 20% �����̰� ���� �������� �ʴ� ����
        if (hunger <= 20.0f && !isBlinking)
        {
            StartCoroutine(BlinkIcon());
        }
    }

    IEnumerator BlinkIcon()
    {
        isBlinking = true;
        if (hunger <= 20.0f)
        {
            hungerIcon.enabled = !hungerIcon.enabled;
            yield return new WaitForSeconds(1.0f); // 1.0�ʸ��� ������
        }
 
        hungerIcon.enabled = true; // ����İ� 20% �̻��̸� ������ ����
        isBlinking = false;
    }

    // ��� ���� �Լ�
    public void DecreaseHunger(float amount)
    {
        hunger -= amount;
        if (hunger < 0) hunger = 0;
    }

    // ��� ȸ�� �Լ�
    public void IncreaseHunger(float amount)
    {
        hunger += amount;
        if (hunger > 100) hunger = 100;
    }
}
