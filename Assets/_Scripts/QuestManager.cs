using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public bool quest1Completed = false;
    public bool quest2Completed = false;
    // 추가적인 퀘스트가 있다면 여기에도 변수를 추가할 수 있습니다.

    public void CompleteQuest1()
    {
        quest1Completed = true;
    }

    public void CompleteQuest2()
    {
        quest2Completed = true;
    }
    // 추가적인 퀘스트가 있다면 여기에도 완료 함수를 추가할 수 있습니다.
}
