using System.Collections;
using UnityEngine;

public class SlidingDoor : MonoBehaviour, IInteraction
{
    float openPositionX = -2.78f;
    float closePositionX = -1.47f;
    float slideSpeed = 1.5f;

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

        float currentX = transform.position.x;
        float targetX = (currentX != openPositionX) ? openPositionX : closePositionX;

        float startTime = Time.time;

        while (Time.time - startTime < Mathf.Abs(currentX - targetX) / slideSpeed)
        {
            float t = (Time.time - startTime) * slideSpeed;

            currentX = Mathf.Lerp(currentX, targetX, t);

            Vector3 targetPosition = new Vector3(currentX, transform.position.y, transform.position.z);
            transform.position = targetPosition;

            yield return null;
        }

        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);

        isMoving = false;
    }

    public string GetInteractPrompt()
    {
        return "Interaction ¿­±â";
    }
}
