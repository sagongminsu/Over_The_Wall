using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour, IOpen
{
    float openRotationX = -90f;
    float closeRotationX = 0f;
    public void Open()
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
}
