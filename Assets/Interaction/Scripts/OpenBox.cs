using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour, IInteraction
{
    public ItemData.Data associatedData;
    float openRotationX = -90f;
    float closeRotationX = 0f;
    public void OnInteract()
    {
        if (transform.rotation.eulerAngles.x != -90f)
        {
            Quaternion targetRotation = Quaternion.Euler(openRotationX, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            transform.rotation = targetRotation;
        }
        else
        {
            Quaternion targetRotation = Quaternion.Euler(closeRotationX, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
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
