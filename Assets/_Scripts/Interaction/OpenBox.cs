using System.Collections;
using UnityEngine;

public class OpenBox : MonoBehaviour, IInteraction
{
    float openRotationX = -90f;
    float closeRotationX = 0f;
    float rotationSpeed = 30f;

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
        float targetRotationX = (currentRotationX != -90f) ? openRotationX : closeRotationX;

        while (Mathf.Abs(currentRotationX - targetRotationX) > 0.1f)
        {
            currentRotationX = Mathf.MoveTowards(currentRotationX, targetRotationX, rotationSpeed * Time.deltaTime);

            Quaternion targetRotation = Quaternion.Euler(currentRotationX, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
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
