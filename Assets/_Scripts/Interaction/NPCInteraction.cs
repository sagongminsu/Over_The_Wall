using UnityEngine;
using TMPro;
using System.Collections;

public class NPCInteraction : MonoBehaviour, IInteraction
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;

    private bool isInteracting = false;
    private bool canInteract = true; // 추가된 변수
    private int currentDialogueIndex = 0;
    private string[] dialogues;

    public void GetDialogues(string[] newDialogues)
    {
        dialogues = newDialogues;
    }

    public void OnInteract()
    {
        if (!isInteracting && dialogues != null && dialogues.Length > 0 && canInteract) // 상호작용 가능한 상태일 때만 대화 시작
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
        dialoguePanel.SetActive(false);
        isInteracting = false;
        currentDialogueIndex = 0;
        canInteract = false;
        StartCoroutine(EnableInteractionAfterDelay(1f));
    }
}
