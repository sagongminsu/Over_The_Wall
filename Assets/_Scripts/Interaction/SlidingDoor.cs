using System.Collections;
using UnityEngine;

public class SlidingDoor : MonoBehaviour, IInteraction
{
    private Collider ObjectCollider;

    float openPositionX = -2.78f;
    float closePositionX = -1.47f;
    float slideSpeed = 1.5f;

    bool isOpen = false;
    bool isMoving = false;

    void Start()
    {
        ObjectCollider = GetComponent<Collider>();
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
        ToggleObject(false);

        float currentX = transform.localPosition.x; // 로컬 좌표계 기준으로 변경
        float targetX = isOpen ? closePositionX : openPositionX;

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

        isOpen = !isOpen;
        isMoving = false;
        ToggleObject(true);
    }

    public string GetInteractPrompt()
    {
        return isOpen ? "Interaction 닫기" : "Interaction 열기";
    }

    private void ToggleObject(bool enable)
    {
        ObjectCollider.enabled = enable;
    }
}
