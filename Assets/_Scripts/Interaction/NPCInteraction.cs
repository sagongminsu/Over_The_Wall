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
                dialogueText.text = "NPC와의 대화가 시작되었습니다: " + dialogue;
            }
            canInteract = false;
            StartCoroutine(ResetInteractionAfterDelay(1f));
        }
    }

    public string GetInteractPrompt()
    {
        if (canInteract)
        {
            return "NPC와 대화하기 (E)";
        }
        else
        {
            return "대화 중입니다...";
        }
    }

    void Update()
    {
        // 'E' 키나 마우스 좌클릭을 누를 때 대화 패널을 닫습니다.
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
