using System.Collections;
using System.Collections.Generic;
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
       
        Inventory.instance.AddItem(item);
        //gameManager.I.clearInterect?.Invoke();
        gameObject.SetActive(false);
    }
}