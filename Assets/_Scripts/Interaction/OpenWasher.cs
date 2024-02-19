using System.Collections;
using UnityEngine;

public class OpenWasher : MonoBehaviour, IInteraction
{
    float openRotationY = 35f;
    float closeRotationY = -35f;
    float rotationSpeed = 50f;

    bool isOpen = false;
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

        Quaternion startRotation = transform.localRotation;
        Quaternion targetRotation = isOpen ? Quaternion.Euler(0, closeRotationY, 0) : Quaternion.Euler(0, openRotationY, 0);

        float elapsedTime = 0f;
        float duration = Quaternion.Angle(startRotation, targetRotation) / rotationSpeed;

        while (elapsedTime < duration)
        {
            transform.localRotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localRotation = targetRotation;
        isOpen = !isOpen;
        isRotating = false;
    }

    public string GetInteractPrompt()
    {
        return isOpen ? "Interaction ¿­±â" : "Interaction ´Ý±â";
    }
}
