using System.Collections;
using UnityEngine;

public class PushingDoor : MonoBehaviour, IInteraction
{
    float openRotationY = 87f;
    float closeRotationY = 0f;
    bool isOpen = false; // Track the door state

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

        float currentRotationY = transform.rotation.eulerAngles.y;
        float targetRotationY = isOpen ? closeRotationY : openRotationY;

        float startTime = Time.time;

        while (Time.time - startTime < 1f)
        {
            float t = (Time.time - startTime) / 1f; // Normalize time between 0 and 1

            currentRotationY = Mathf.Lerp(currentRotationY, targetRotationY, t);

            Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, currentRotationY, transform.rotation.eulerAngles.z);
            transform.rotation = targetRotation;

            yield return null;
        }

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, targetRotationY, transform.rotation.eulerAngles.z);

        isOpen = !isOpen; // Toggle the door state
        isMoving = false;
    }

    public string GetInteractPrompt()
    {
        return "Interaction ¿­±â";
    }
}
