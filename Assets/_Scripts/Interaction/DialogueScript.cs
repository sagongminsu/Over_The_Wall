using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    [SerializeField] private NPCInteraction npcInteraction;

    private void Start()
    {
        string[] dialogues = new string[]
        {
            "ù ��° ��ȭ",
            "�� ��° ��ȭ",
            "�� ��° ��ȭ",
            // �ʿ��� ��ŭ ��ȭ�� �߰�����
        };

        npcInteraction.GetDialogues(dialogues);
    }
}