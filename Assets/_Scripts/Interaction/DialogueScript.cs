using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    [SerializeField] private NPCInteraction npcInteraction;
    [SerializeField] private QuestManager questManager;

    private void Start()
    {
        string[] dialogues = new string[]
        {
            "자네는 이번에 온 신입인가?",
            "감옥이 심심한 것 같다면 뭐 이것저것 해보게",
            "저쪽 갱단의 보스는 재밌는 일을 벌일 생각인가 보더군",
            // 필요한 만큼 대화를 추가가능
        };

        npcInteraction.GetDialogues(dialogues);
    }
}
