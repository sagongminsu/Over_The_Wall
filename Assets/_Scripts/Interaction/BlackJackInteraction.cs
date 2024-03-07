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
        if (blackJack != null && !blackJack.activeSelf)
        {
            blackJack.SetActive(true);


            Cursor.lockState = CursorLockMode.None;

        }
    }
}
