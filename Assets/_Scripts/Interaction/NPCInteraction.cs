using UnityEngine;
using TMPro;
using System.Collections;

public class NPCInteraction : MonoBehaviour, IInteraction
{
    public string dialogue;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;

    private bool canInteract = true;

    public void OnInteract()
    {
        if (canInteract)
        {
            dialoguePanel.SetActive(true);
            if (dialogueText != null)
            {
                dialogueText.text = "NPC���� ��ȭ�� ���۵Ǿ����ϴ�: " + dialogue;
            }
            canInteract = false;
            StartCoroutine(ResetInteractionAfterDelay(1f));
        }
    }

    public string GetInteractPrompt()
    {
        if (canInteract)
        {
            return "NPC�� ��ȭ�ϱ� (E)";
        }
        else
        {
            return "��ȭ ���Դϴ�...";
        }
    }

    void Update()
    {
        // 'E' Ű�� ���콺 ��Ŭ���� ���� �� ��ȭ �г��� �ݽ��ϴ�.
        if (!canInteract && (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)))
        {
            CloseDialoguePanel();
        }
    }

    IEnumerator ResetInteractionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canInteract = true;
    }

    void CloseDialoguePanel()
    {
        dialoguePanel.SetActive(false);
        StartCoroutine(EnableInteractionAfterDelay(1f));
    }

    IEnumerator EnableInteractionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canInteract = true;
    }
}
