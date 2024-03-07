using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackJackInteraction : MonoBehaviour, IInteraction
{
    public GameObject blackJack;

    public string GetInteractPrompt()
    {
        return "Interaction 블랙잭";
    }

    public void OnInteract()
    {
        // blackJack 게임 오브젝트가 존재하고 활성화되어 있지 않은 경우에만 활성화합니다.
        if (blackJack != null && !blackJack.activeSelf)
        {
            blackJack.SetActive(true);
        }
    }
}
