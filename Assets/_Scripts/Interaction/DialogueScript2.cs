using UnityEngine;

public class DialogueScript2 : MonoBehaviour
{
    [SerializeField] private NPCInteraction npcInteraction;
    [SerializeField] private QuestManager questManager;

    public void Dialogues2()
    {
        string[] dialogues;

        // ����Ʈ ���� ���¿� ���� ��ȭ ����
        if (questManager.quest2progress == true)
        {
            dialogues = new string[]
            {
                "�츮 ���ᰡ �����ִ� ������ ���踦 �������� �ʵ� ���� ������ ���ֵ�������."
            };
        }
        else if (questManager.quest1Completed == true)
        {
            dialogues = new string[]
            {
                "��մ� ���� ���İ�? ��� �׷� �ҹ��� ��� �°���?",
                "�� �ϱ⿣ ���� �츮�� �ŷڵ��� �����ѵ�",
                "�츮 ���ᰡ �����ִ� ������ ���踦 �������� �ʵ� ���� ������ ���ֵ�������."
            };
        }
        else
        {
            // ����Ʈ�� ���� ���۵��� �ʾ��� ���� ��ȭ
            dialogues = new string[]
            {
                "����Ʈ�� ���� ���۵��� �ʾҽ��ϴ�."
            };
        }

        npcInteraction.GetDialogues(dialogues);
    }
}
