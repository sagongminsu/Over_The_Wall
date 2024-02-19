using UnityEngine;
using TMPro;

public class TaskTMP : MonoBehaviour
{
    [SerializeField] private QuestManager questManager;
    [SerializeField] private TextMeshProUGUI taskText;

    void Update()
    {
        UpdateTaskText();
    }

    void UpdateTaskText()
    {
        // ���� ���� ���� ����Ʈ ���¿� ���� UI �ؽ�Ʈ ����
        if (questManager.quest2progress)
        {
            taskText.text = "���� ������ ���� ���踦 ���ؿ���.";
        }
        else if (questManager.quest1Completed)
        {
            taskText.text = "���� ������ ��ȭ�ϱ�.";
        }
        else
        {
            taskText.text = "NPC �˼��� ã�ư��� ��ȭ�ϱ�.";
        }
    }
}
