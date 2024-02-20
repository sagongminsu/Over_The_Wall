using UnityEngine;
using System.Collections;

public class PushingDoor : MonoBehaviour, IInteraction
{
    private Collider ObjectCollider;
    private AudioSource audioSource; // AudioSource 컴포넌트를 저장할 변수 추가

    public AudioClip doorSound; // 문 열고 닫힐 때 재생할 사운드 파일

    float openRotationY = 87f;
    float closeRotationY = 0f;

    bool isOpen = false;
    bool isMoving = false;

    private void Start()
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

        float targetRotationY = isOpen ? closeRotationY : openRotationY;

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
        ToggleObject(true);
        audioSource.PlayOneShot(doorSound); // 열리는/닫히는 소리 재생
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
