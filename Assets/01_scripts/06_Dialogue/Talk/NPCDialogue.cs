using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour, IInteraction
{
    public string interactPrompt = "대화하기";

    // TMP Text 객체 참조
    public TMP_Text dialogueText;

    // 대화 상자 게임 오브젝트 참조
    public GameObject dialogueBox;

    // NPC와의 대화 내용 배열
    public string[] dialogues;

    // 현재 진행 중인 대화 인덱스
    private int currentDialogueIndex = 0;

    // 대화 상태 변수
    private bool isTalking = false;

    // 대화 시작 함수
    public void StartDialogue()
    {
        if (dialogues.Length > 0)
        {
            isTalking = true;
            currentDialogueIndex = 0;
            DisplayNextDialogue();
            // 대화 시작 시 대화 상자를 활성화합니다.
            dialogueBox.SetActive(true);
        }
    }

    // 다음 대화 표시 함수
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

    // 대화 종료 함수
    protected virtual void EndDialogue()
    {
        Debug.Log("대화 종료");
        isTalking = false;
        currentDialogueIndex = 0;
        // 대화 종료 시 대화 상자를 비활성화합니다.
        dialogueBox.SetActive(false);
        // 대화 종료 시 TMP Text를 비웁니다.
        dialogueText.text = string.Empty;
    }

    // 대화 진행 여부 확인 함수
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
