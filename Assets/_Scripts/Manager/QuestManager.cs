using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public ScheduleUI scheduleUI;

    // 각 퀘스트의 완료 상태를 저장하는 배열
    private bool[] questStatus = new bool[5];

    void Start()
    {
        InitializeQuests();
    }

    // 퀘스트 상태 초기화 메서드
    void InitializeQuests()
    {
        for (int i = 0; i < questStatus.Length; i++)
        {
            questStatus[i] = false;
        }
    }

    // 퀘스트 완료를 처리하는 메서드
    public void CompleteQuest(int questNumber)
    {
        Debug.Log("퀘스트 완료");

        scheduleUI.UpdateDay0TextForQuest(questNumber);
        questStatus[questNumber - 1] = true;
    }
}
