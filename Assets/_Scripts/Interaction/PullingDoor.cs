using System.Collections;
using UnityEngine;

public class PullingDoor : MonoBehaviour, IInteraction
{
    float openRotationY = -87f;
    float closeRotationY = 0f;
    bool isOpen = false;

    bool isMoving = false;

    public void OnInteract()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveDoor());
        }
    }

    IEnumerator MoveDoor()
    {
        isMoving = true;

        float targetRotationY = isOpen ? closeRotationY : openRotationY;

        if (isOpen)
        {
            if (targetRotationY != -87f) targetRotationY = -87f;
        }
        else
        {
            if (targetRotationY == -87f) targetRotationY = 0f;
        }

        Quaternion targetRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, targetRotationY, transform.localRotation.eulerAngles.z);

        float elapsedTime = 0f;
        float moveTime = 1f;

        while (elapsedTime < moveTime)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, elapsedTime / moveTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localRotation = targetRotation;
        isOpen = !isOpen;
        isMoving = false;
    }

    public string GetInteractPrompt()
    {
        return "Interaction ¿­±â";
    }
}
