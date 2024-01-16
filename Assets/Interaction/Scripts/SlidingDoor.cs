using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour, IInteraction
{
    public JsonLoader.ItemData associatedData;
    float openPositionX = -2.78f;
    float closePositionX = -1.47f;
    public void OnInteract()
    {
        if (transform.position.x != -2.78f)
        {
            Vector3 targetPosition = new Vector3(openPositionX, transform.position.y, transform.position.z);
            transform.position = targetPosition;
        }
        else
        {
            Vector3 targetPosition = new Vector3(closePositionX, transform.position.y, transform.position.z);
            transform.position = targetPosition;
        }
    }

    public string GetInteractPrompt()
    {
        if (associatedData != null && associatedData.ItemList.Count == 7)
        {

            JsonLoader.ItemData.Item item = associatedData.ItemList[7];
            return string.Format("Interaction {0}", item.InteractionName);

        }
        else
        {
            return "Interaction";
        }
    }
}