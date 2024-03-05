using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Rendering;
using UnityEngine;

public class ShopOpen : MonoBehaviour, IInteraction
{
    public GameObject ShopWindow;
    public GameObject ShopMan;

    private void Update()
    {
        if (gameManager.I.CheckTime(14, 17))
        {
            ShopMan.SetActive(true);
        }
        else
        {
            ShopMan.SetActive(false);
        }
    }
    public string GetInteractPrompt()
    {
        return string.Format("����");
    }

    public void OnInteract()
    {
      ShopWindow.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }
}
