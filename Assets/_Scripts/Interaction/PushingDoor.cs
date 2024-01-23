using System.Collections;
using UnityEngine;

public class PushingDoor : MonoBehaviour, IInteraction
{
    float openRotationY = 87f;
    float closeRotationY = 0f;
    float rotationSpeed = 60f;

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
        float targetRotationY = (currentRotationY != 87f) ? openRotationY : closeRotationY;

        while (Mathf.Abs(currentRotationY - targetRotationY) > 0.1f)
        {
            currentRotationY = Mathf.MoveTowards(currentRotationY, targetRotationY, rotationSpeed * Time.deltaTime);

            Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, currentRotationY, transform.rotation.eulerAngles.z);
            transform.rotation = targetRotation;

            yield return null;
        }

        isMoving = false;
    }

    public string GetInteractPrompt()
    {
        return "Interaction ¿­±â";
    }
}
