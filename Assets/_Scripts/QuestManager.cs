using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private DialogueScript2 dialogueScript2;

    public bool quest1Completed = false;
    public bool quest2Completed = false;
    public bool quest2progress = false;

    public void CompleteQuest1()
    {
        if (quest1Completed == false)
        {
            quest1Completed = true;
            dialogueScript2.Dialogues2(); // 퀘스트1 완료 후 다음 대화 설정
        }
    }

    public void CompleteQuest2()
    {
        if (quest1Completed == true)
        {
            quest2progress = true; // 퀘스트1 완료 후 퀘스트2 진행 시작
        }
    }
}
