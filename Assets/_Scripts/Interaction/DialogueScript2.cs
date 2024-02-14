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
                "어디서 그런 소문을 듣고 온거지?",
                "쓸데없는 소리를 하고 다니는 녀석은 혼을 좀 내줘야겠군.",
                "널 믿기엔 아직 신뢰도가 부족한데",
                "우리 동료가 갇혀있는 독방의 열쇠를 가져오면 너도 같이 나가게 해주도록하지."
            };
        }
        else if (questManager.quest2Completed)
        {
            dialogues = new string[]
            {
                "우리 동료가 갇혀있는 독방의 열쇠를 가져오면 너도 같이 나가게 해주도록하지."
            };
        }
        else
        {
            // 퀘스트가 아직 시작되지 않았을 때의 대화
            dialogues = new string[]
            {
                "퀘스트가 아직 시작되지 않았습니다."
            };
        }

        npcInteraction.GetDialogues(dialogues);
    }

    // 대화 종료 후 호출되는 함수
    public void OnDialogueEnd()
    {
        if (questManager.quest2Completed == false)
        {
            questManager.CompleteQuest2();
        }
    }
}
