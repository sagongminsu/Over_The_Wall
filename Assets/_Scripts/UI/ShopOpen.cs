using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Rendering;
using UnityEngine;

public class ShopOpen : MonoBehaviour, IInteraction
{
    public GameObject ShopWindow;

    public string GetInteractPrompt()
    {
        return string.Format("ªÛ¡°");
    }

    public void OnInteract()
    {
      ShopWindow.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }
}
