using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenActive : MonoBehaviour
{
    public GameObject[] objectsToActivate; // Ȱ��ȭ�� ������Ʈ �迭
    private bool ShopMenActivateToday = false; // ���� Ȱ��ȭ�Ǿ����� ����
    private int lastDay = -1; // ���������� Ȱ��ȭ�� ��¥

    void Update()
    {
        int Day = gameManager.I.dayNightCycle.Days;
        // ��¥�� �ٲ�� Ȱ��ȭ ���� �ʱ�ȭ
        if (Day != lastDay)
        {
            ShopMenActivateToday = false;
            lastDay = Day;
        }

        // ������ �ð��뿡�� ������Ʈ���� Ȱ��ȭ
        if (gameManager.I.CheckTime(14, 17) && !ShopMenActivateToday)
        {
            foreach (var objectToActivate in objectsToActivate)
            {
                objectToActivate.SetActive(true);
            }
            ShopMenActivateToday = true; // ������Ʈ���� Ȱ��ȭ�ߴٰ� ǥ��
        }
        else if (!gameManager.I.CheckTime(14, 17) && ShopMenActivateToday)
        {
            // ������ �ð��밡 �ƴ϶�� ������Ʈ���� ��Ȱ��ȭ
            foreach (var objectToActivate in objectsToActivate)
            {
                objectToActivate.SetActive(false);
            }
            ShopMenActivateToday = false; // ������Ʈ���� ��Ȱ��ȭ�ߴٰ� ǥ��
        }
    }
}
