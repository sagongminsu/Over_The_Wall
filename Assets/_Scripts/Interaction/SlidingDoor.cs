using System.Collections;
using UnityEngine;

public class SlidingDoor : MonoBehaviour, IInteraction
{
    float openPositionX = -2.78f;
    float closePositionX = -1.47f;
    float slideSpeed = 1.5f;

    bool isMoving = false;

    // 추가된 변수
    Transform parentTransform;

    void Start()
    {
        // 부모 Transform 참조
        parentTransform = transform.parent;
    }

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

        float currentX = transform.localPosition.x; // 로컬 좌표계 기준으로 변경
        float targetX = (currentX != openPositionX) ? openPositionX : closePositionX;

        float startTime = Time.time;

        while (Time.time - startTime < Mathf.Abs(currentX - targetX) / slideSpeed)
        {
            float t = (Time.time - startTime) * slideSpeed;

            currentX = Mathf.Lerp(currentX, targetX, t);

            Vector3 targetPosition = new Vector3(currentX, transform.localPosition.y, transform.localPosition.z);
            transform.localPosition = targetPosition;

            yield return null;
        }

        transform.localPosition = new Vector3(targetX, transform.localPosition.y, transform.localPosition.z);

        isMoving = false;
    }

    public string GetInteractPrompt()
    {
        return "Interaction 열기";
    }
}