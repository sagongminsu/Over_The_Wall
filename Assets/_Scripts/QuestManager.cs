using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public bool quest1Completed = false;
    public bool quest2Completed = false;
    // �߰����� ����Ʈ�� �ִٸ� ���⿡�� ������ �߰��� �� �ֽ��ϴ�.

    public void CompleteQuest1()
    {
        quest1Completed = true;
    }

    public void CompleteQuest2()
    {
        quest2Completed = true;
    }
    // �߰����� ����Ʈ�� �ִٸ� ���⿡�� �Ϸ� �Լ��� �߰��� �� �ֽ��ϴ�.
}
