using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    [SerializeField] private NPCInteraction npcInteraction;
    [SerializeField] private QuestManager questManager;

    private void Start()
    {
        string[] dialogues = new string[]
        {
            "�ڳ״� �̹��� �� �����ΰ�?",
            "������ �ɽ��� �� ���ٸ� �� �̰����� �غ���",
            "���� ������ ������ ��մ� ���� ���� �����ΰ� ������",
            // �ʿ��� ��ŭ ��ȭ�� �߰�����
        };

        npcInteraction.GetDialogues(dialogues);
    }

    // ��ȭ ���� �� ȣ��Ǵ� �Լ�
    public void OnDialogueEnd()
    {
        if (questManager.quest1Completed == false)
        {
            questManager.CompleteQuest1(); // ù ��° ����Ʈ �Ϸ�
        }
    }
}
