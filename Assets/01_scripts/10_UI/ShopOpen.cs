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
     
            ShopMan.SetActive(gameManager.I.CheckTime(14,17));
      
    }
    public string GetInteractPrompt()
    {
        return string.Format("ªÛ¡°");
    }

    public void OnInteract()
    {
       
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        ShopWindow.SetActive(true);
    }
    
}
