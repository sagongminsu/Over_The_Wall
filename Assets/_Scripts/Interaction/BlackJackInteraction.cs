using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackJackInteraction : MonoBehaviour, IInteraction
{
    public GameObject blackJack;

    public string GetInteractPrompt()
    {
        return "Interaction ����";
    }

    public void OnInteract()
    {
        // blackJack ���� ������Ʈ�� �����ϰ� Ȱ��ȭ�Ǿ� ���� ���� ��쿡�� Ȱ��ȭ�մϴ�.
        if (blackJack != null && !blackJack.activeSelf)
        {
            blackJack.SetActive(true);
        }
    }
}
