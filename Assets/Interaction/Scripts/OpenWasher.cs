using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWasher : MonoBehaviour, IInteraction
{
    public ItemData.Object associatedData;

    float openRotationY = 35f;
    float closeRatationY = -35f;
    public void OnInteract()
    {
        if (transform.rotation.eulerAngles.y != 35f)
        {
            Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, openRotationY, transform.rotation.eulerAngles.z);
            transform.rotation = targetRotation;
        }
        else
        {
            Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, closeRatationY, transform.rotation.eulerAngles.z);
            transform.rotation = targetRotation;
        }
    }

    public string GetInteractPrompt()
    {
        if (associatedData != null)
        {
            return string.Format("Interaction {0}", associatedData.displayName);
        }
        else
        {
            return "Interaction";
        }
    }
}
