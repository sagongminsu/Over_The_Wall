using System.Collections;
using UnityEngine;

public class SlidingDoor : MonoBehaviour, IInteraction
{
    private Collider ObjectCollider;
    private AudioManager audioManager;
    private Teleport teleport;

    float openPositionX = -2.78f;
    float closePositionX = -1.47f;
    float slideSpeed = 1.5f;

    bool isOpen = false;
    bool isMoving = false;
    bool lockDoor = false;
    void Start()
    {
        ObjectCollider = GetComponent<Collider>();
        audioManager = AudioManager.Instance; // AudioManager 인스턴스 가져오기

    }
    void Update()
    {
        if (gameManager.I.dayNightCycle.time < 360f || gameManager.I.dayNightCycle.time > 1380f)
        {
            lockDoor = true;
            Vector3 targetPosition = new Vector3(closePositionX, transform.localPosition.y, transform.localPosition.z);
            transform.localPosition = targetPosition;
            isOpen = false;
        }
        else
        {
            lockDoor = false;
        }
    }



    public void OnInteract()
    {
        if (lockDoor == false)
        {
            if (!isMoving)
            {
                StartCoroutine(MoveDoor());
            }
        }
        else
        {
            return;
        }
    }


    IEnumerator MoveDoor()
    {
        isMoving = true;
        ToggleObject(false);

        float currentX = transform.localPosition.x; // 로컬 좌표계 기준으로 변경
        float targetX = isOpen ? closePositionX : openPositionX;

        float startTime = Time.time;
        audioManager.PlayDoorSound(1); // AudioManager에서 두 번째 door sound 재생

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
        if (lockDoor == false)
        {
            return isOpen ? "Interaction 닫기" : "Interaction 열기";
        }
        else
        {
            return "잠김";
        }
    }


    private void ToggleObject(bool enable)
    {
        ObjectCollider.enabled = enable;
    }
}
