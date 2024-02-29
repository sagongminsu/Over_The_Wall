using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour, IInteraction
{
    public string interactPrompt = "��ȭ�ϱ�";

    // TMP Text ��ü ����
    public TMP_Text dialogueText;

    // ��ȭ ���� ���� ������Ʈ ����
    public GameObject dialogueBox;

    // NPC���� ��ȭ ���� �迭
    public string[] dialogues;

    // ���� ���� ���� ��ȭ �ε���
    private int currentDialogueIndex = 0;

    // ��ȭ ���� ����
    private bool isTalking = false;

    // ��ȭ ���� �Լ�
    public void StartDialogue()
    {
        if (dialogues.Length > 0)
        {
            isTalking = true;
            currentDialogueIndex = 0;
            DisplayNextDialogue();
            // ��ȭ ���� �� ��ȭ ���ڸ� Ȱ��ȭ�մϴ�.
            dialogueBox.SetActive(true);
        }
    }

    // ���� ��ȭ ǥ�� �Լ�
    private void DisplayNextDialogue()
    {
        if (currentDialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[currentDialogueIndex];
            currentDialogueIndex++;
        }
        else
        {
            EndDialogue();
        }
    }

    // ��ȭ ���� �Լ�
    protected virtual void EndDialogue()
    {
        Debug.Log("��ȭ ����");
        isTalking = false;
        currentDialogueIndex = 0;
        // ��ȭ ���� �� ��ȭ ���ڸ� ��Ȱ��ȭ�մϴ�.
        dialogueBox.SetActive(false);
        // ��ȭ ���� �� TMP Text�� ���ϴ�.
        dialogueText.text = string.Empty;
    }

    // ��ȭ ���� ���� Ȯ�� �Լ�
    public bool IsTalking()
    {
        return isTalking;
    }

    public string GetInteractPrompt()
    {
        return interactPrompt;
    }

    public virtual void OnInteract()
    {
        if (isTalking)
        {
            DisplayNextDialogue();
        }
        else
        {
            StartDialogue();
        }
    }
}
