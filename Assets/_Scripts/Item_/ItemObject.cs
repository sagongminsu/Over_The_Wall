using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour, IInteraction
{
    public ItemData_ item;
   
    public bool ObjectSwitch { get { return objectSwitch; } }
    private bool objectSwitch = true;


    public string GetInteractPrompt()
    {
        return string.Format("Pickup {0}", item.displayName);
    }

    public void OnInteract()
    {
        gameObject.SetActive(false);
        Inventory.instance.AddItem(item);
        objectSwitch = false;
    }
}