using System.Collections;
using UnityEngine;

public class OpenWasher : MonoBehaviour, IInteraction
{
    float openRotationY = 35f;
    float closeRotationY = -35f;
    float rotationSpeed = 50f;

    bool isRotating = false;

    public void OnInteract()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateWasher());
        }
    }

    IEnumerator RotateWasher()
    {
        isRotating = true;

        float currentY = transform.rotation.eulerAngles.y;
        float targetY = (currentY != openRotationY) ? openRotationY : closeRotationY;

        while (Mathf.Abs(currentY - targetY) > 0.01f)
        {
            currentY = Mathf.MoveTowards(currentY, targetY, rotationSpeed * Time.deltaTime);

            Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, currentY, transform.rotation.eulerAngles.z);
            transform.rotation = targetRotation;

            yield return null;
        }

        isRotating = false;
    }

    public string GetInteractPrompt()
    {
        return "Interaction ¿­±â";
    }
}
