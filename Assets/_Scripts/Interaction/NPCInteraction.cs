using UnityEngine;
using TMPro;
using System.Collections;

public class NPCInteraction : MonoBehaviour, IInteraction
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public QuestManager questManager;

    private bool isInteracting = false;
    private bool canInteract = true;
    private int currentDialogueIndex = 0;
    private string[] dialogues;

    public void GetDialogues(string[] newDialogues)
    {
        dialogues = newDialogues;
    }

    public void OnInteract()
    {
        // 대화 중 또는 상호작용 불가능한 상태에서는 대화를 시작하지 않음
        if (!isInteracting && dialogues != null && dialogues.Length > 0 && canInteract)
        {
            StartDialogue();
        }
    }

    private void StartDialogue()
    {
        isInteracting = true;
        dialoguePanel.SetActive(true);
        ShowNextDialogue();
    }

    private void ShowNextDialogue()
    {
        if (currentDialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[currentDialogueIndex];
            currentDialogueIndex++;
        }
        else
        {
            CloseDialoguePanel();
        }
    }

    public string GetInteractPrompt()
    {
        return isInteracting ? "대화 중입니다..." : "NPC와 대화하기 (E)";
    }

    void Update()
    {
        if (isInteracting && (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)))
        {
            if (currentDialogueIndex < dialogues.Length)
            {
                ShowNextDialogue();
            }
            else
            {
                CloseDialoguePanel();
            }
        }
    }

    IEnumerator EnableInteractionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canInteract = true;
    }

    void CloseDialoguePanel()
    {
        // 퀘스트 상태에 따라 대화가 종료된 후의 동작을 다르게 처리
        if (questManager.quest1Completed == true)
        {
            questManager.CompleteQuest2();
        }
        dialoguePanel.SetActive(false);
        questManager.CompleteQuest1();

        // 대화 종료 후 초기화
        isInteracting = false;
        currentDialogueIndex = 0;
        canInteract = false;
        StartCoroutine(EnableInteractionAfterDelay(1f));
    }
}
