using UnityEngine;
using System.Collections;

public class PushingDoor : MonoBehaviour, IInteraction
{
    private Collider ObjectCollider;
    private AudioSource audioSource; // AudioSource ������Ʈ�� ������ ���� �߰�

    public AudioClip doorSound; // �� ���� ���� �� ����� ���� ����

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
        audioSource.PlayOneShot(doorSound); // ������/������ �Ҹ� ���
    }

    public string GetInteractPrompt()
    {
        return isOpen ? "Interaction �ݱ�" : "Interaction ����";
    }

    private void ToggleObject(bool enable)
    {
        ObjectCollider.enabled = enable;
    }
}
