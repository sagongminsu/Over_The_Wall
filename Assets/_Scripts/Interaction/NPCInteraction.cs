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
        // ��ȭ �� �Ǵ� ��ȣ�ۿ� �Ұ����� ���¿����� ��ȭ�� �������� ����
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
        return isInteracting ? "��ȭ ���Դϴ�..." : "NPC�� ��ȭ�ϱ� (E)";
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
        // ����Ʈ ���¿� ���� ��ȭ�� ����� ���� ������ �ٸ��� ó��
        if (questManager.quest1Completed == true)
        {
            questManager.CompleteQuest2();
        }
        dialoguePanel.SetActive(false);
        questManager.CompleteQuest1();

        // ��ȭ ���� �� �ʱ�ȭ
        isInteracting = false;
        currentDialogueIndex = 0;
        canInteract = false;
        StartCoroutine(EnableInteractionAfterDelay(1f));
    }
}
