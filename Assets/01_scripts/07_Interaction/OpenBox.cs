using System.Collections;
using UnityEngine;

public class OpenBox : MonoBehaviour, IInteraction
{
    float openRotationX = -90f;
    float closeRotationX = 0f;
    float rotationSpeed = 15f;

    bool isOpen = false;
    bool isMoving = false;

    public void OnInteract()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveBox());
        }
    }

    IEnumerator MoveBox()
    {
        isMoving = true;

        float currentRotationX = transform.rotation.eulerAngles.x;
        float targetRotationX = isOpen ? closeRotationX : openRotationX;
        float direction = isOpen ? -1f : 1f;

        while (Mathf.Abs(currentRotationX - targetRotationX) > 0.1f)
        {
            currentRotationX += direction * rotationSpeed * Time.deltaTime;
            currentRotationX = Mathf.Clamp(currentRotationX, closeRotationX, openRotationX);

            Quaternion targetRotation = Quaternion.Euler(currentRotationX, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            transform.rotation = targetRotation;

            yield return null;
        }

        isOpen = !isOpen;
        isMoving = false;
    }

    public string GetInteractPrompt()
    {
        return isOpen ? "Interaction ´Ý±â" : "Interaction ¿­±â";
    }
}
