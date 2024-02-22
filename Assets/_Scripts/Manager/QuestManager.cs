using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public ScheduleUI scheduleUI;

    // �� ����Ʈ�� �Ϸ� ���¸� �����ϴ� �迭
    private bool[] questStatus = new bool[5];

    void Start()
    {
        InitializeQuests();
    }

    // ����Ʈ ���� �ʱ�ȭ �޼���
    void InitializeQuests()
    {
        for (int i = 0; i < questStatus.Length; i++)
        {
            questStatus[i] = false;
        }
    }

    // ����Ʈ �ϷḦ ó���ϴ� �޼���
    public void CompleteQuest(int questNumber)
    {
        Debug.Log("����Ʈ �Ϸ�");

        scheduleUI.UpdateDay0TextForQuest(questNumber);
        questStatus[questNumber - 1] = true;
    }
}
