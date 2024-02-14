using UnityEngine;

public class DialogueScript2 : MonoBehaviour
{
    [SerializeField] private NPCInteraction npcInteraction;
    [SerializeField] private QuestManager questManager;

    private void Start()
    {
        string[] dialogues;

        if (questManager.quest1Completed)
        {
            dialogues = new string[]
            {
                "��� �׷� �ҹ��� ��� �°���?",
                "�������� �Ҹ��� �ϰ� �ٴϴ� �༮�� ȥ�� �� ����߰ڱ�.",
                "�� �ϱ⿣ ���� �ŷڵ��� �����ѵ�",
                "�츮 ���ᰡ �����ִ� ������ ���踦 �������� �ʵ� ���� ������ ���ֵ�������."
            };
        }
        else if (questManager.quest2Completed)
        {
            dialogues = new string[]
            {
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

    // ��ȭ ���� �� ȣ��Ǵ� �Լ�
    public void OnDialogueEnd()
    {
        if (questManager.quest2Completed == false)
        {
            questManager.CompleteQuest2();
        }
    }
}
