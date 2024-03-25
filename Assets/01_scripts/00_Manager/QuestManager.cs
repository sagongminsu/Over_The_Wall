using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    [Header("QuestData")]
    public List<QuestData> Quests = new List<QuestData>();

    public ScheduleUI scheduleUI;


    // �� ����Ʈ�� �Ϸ� ���¸� �����ϴ� �迭
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
   

    // ����Ʈ ���� �ʱ�ȭ �޼���
    private void InitializeQuests()
    {
        for (int i = 0; i < questStatus.Length; i++)
        {
            questStatus[i] = false;
        }
    }

    // ����Ʈ �ϷḦ ó���ϴ� �޼���
    public void CompleteQuest(int questNumber)
    {
        Debug.Log($"����Ʈ {questNumber} �Ϸ�");
        questStatus[questNumber - 1] = true;
        UpdateQuestImages();
    }

    // �̹��� ������Ʈ �޼���
    void UpdateQuestImages()
    {
        for (int i = 0; i < questImages.Length; i++)
        {
            // �� ����Ʈ �̹����� Ȱ��ȭ ���θ� questStatus �迭 ���� ���� �����մϴ�.
            questImages[i].gameObject.SetActive(questStatus[i]);
        }

    }
    public bool GetQuestState(int questNumber)
    {
        return questStatus[questNumber - 1];
    }

}
