using UnityEngine;

public class DialogueScript2 : MonoBehaviour
{
    [SerializeField] private NPCInteraction npcInteraction;
    [SerializeField] private QuestManager questManager;

    public void Dialogues2()
    {
        string[] dialogues;

        // 퀘스트 진행 상태에 따라 대화 설정
        if (questManager.quest2progress == true)
        {
            dialogues = new string[]
            {
                "우리 동료가 갇혀있는 독방의 열쇠를 가져오면 너도 같이 나가게 해주도록하지."
            };
        }
        else if (questManager.quest1Completed == true)
        {
            dialogues = new string[]
            {
                "재밌는 일이 뭐냐고? 어디서 그런 소문을 듣고 온거지?",
                "널 믿기엔 아직 우리의 신뢰도가 부족한데",
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
}
