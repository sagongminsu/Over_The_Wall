using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractingPeople : MonoBehaviour
{
    public GameObject[] objectsToActivate; // Ȱ��ȭ�� ������Ʈ �迭
    private bool hasBeenActivatedToday = false; // ���� Ȱ��ȭ�Ǿ����� ����
    private int lastActivationDay = -1; // ���������� Ȱ��ȭ�� ��¥

    void Update()
    {
        int currentDay = gameManager.I.dayNightCycle.Days;
        // ��¥�� �ٲ�� Ȱ��ȭ ���� �ʱ�ȭ
        if (currentDay != lastActivationDay)
        {
            hasBeenActivatedToday = false;
            lastActivationDay = currentDay;
        }

        // ������ �ð��뿡�� ������Ʈ���� Ȱ��ȭ
        if (gameManager.I.CheckTime(13, 14) && !hasBeenActivatedToday)
        {
            foreach (var objectToActivate in objectsToActivate)
            {
                objectToActivate.SetActive(true);
            }
            hasBeenActivatedToday = true; // ������Ʈ���� Ȱ��ȭ�ߴٰ� ǥ��
        }
        else if (!gameManager.I.CheckTime(13, 14) && hasBeenActivatedToday)
        {
            // ������ �ð��밡 �ƴ϶�� ������Ʈ���� ��Ȱ��ȭ
            foreach (var objectToActivate in objectsToActivate)
            {
                objectToActivate.SetActive(false);
            }
            hasBeenActivatedToday = false; // ������Ʈ���� ��Ȱ��ȭ�ߴٰ� ǥ��
        }
    }
}