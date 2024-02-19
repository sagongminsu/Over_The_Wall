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
}
