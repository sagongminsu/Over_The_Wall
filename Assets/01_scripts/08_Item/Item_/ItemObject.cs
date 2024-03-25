using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ItemObject : MonoBehaviour, IInteraction
{
    public ItemData_ item;


     
     

   
    public string GetInteractPrompt()
    {
        return string.Format("Pickup {0}", item.displayName);
    }

    public void OnInteract()
    {
        gameObject.SetActive(false);
        Inventory.instance.AddItem(item);
      
    }
}