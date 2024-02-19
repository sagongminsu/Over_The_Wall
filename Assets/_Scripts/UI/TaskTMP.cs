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
        // 현재 진행 중인 퀘스트 상태에 따라 UI 텍스트 설정
        if (questManager.quest2progress)
        {
            taskText.text = "갱단 보스가 말한 열쇠를 구해오기.";
        }
        else if (questManager.quest1Completed)
        {
            taskText.text = "갱단 보스와 대화하기.";
        }
        else
        {
            taskText.text = "NPC 죄수를 찾아가서 대화하기.";
        }
    }
}
