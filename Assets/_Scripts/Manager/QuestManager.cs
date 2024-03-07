using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    [Header("QuestData")]
    public List<QuestData> Quests = new List<QuestData>();

    public ScheduleUI scheduleUI;


    // 각 퀘스트의 완료 상태를 저장하는 배열
    private bool[] questStatus = new bool[5];

    public Image[] questImages;

    public static QuestManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    void Start()
    {
        InitializeQuests();
        UpdateQuestImages();
    }
   

    // 퀘스트 상태 초기화 메서드
    private void InitializeQuests()
    {
        for (int i = 0; i < questStatus.Length; i++)
        {
            questStatus[i] = false;
        }
    }

    // 퀘스트 완료를 처리하는 메서드
    public void CompleteQuest(int questNumber)
    {
        Debug.Log($"퀘스트 {questNumber} 완료");
        questStatus[questNumber - 1] = true;
        UpdateQuestImages();
    }

    // 이미지 업데이트 메서드
    void UpdateQuestImages()
    {
        for (int i = 0; i < questImages.Length; i++)
        {
            // 각 퀘스트 이미지의 활성화 여부를 questStatus 배열 값에 따라 설정합니다.
            questImages[i].gameObject.SetActive(questStatus[i]);
        }

    }
    public bool GetQuestState(int questNumber)
    {
        return questStatus[questNumber - 1];
    }

}
