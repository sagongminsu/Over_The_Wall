using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingDoor : MonoBehaviour, IInteraction
{
    float openRotationY = 90f;
    float closeRotationY = 0f;
    public void OnInteract()
    {
        if(transform.rotation.eulerAngles.y != 90f)
        {
            Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, openRotationY, transform.rotation.eulerAngles.z);
            transform.rotation = targetRotation;
        }
        else
        {
            Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, closeRotationY, transform.rotation.eulerAngles.z);
            transform.rotation = targetRotation;
        }
    }
}
