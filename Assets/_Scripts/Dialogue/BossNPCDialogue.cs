
public class BossNPCDialogue : NPCDialogue
{
    public QuestManager questManager;
    void Start()
    {
        dialogues = new string[]
        {
            "이번에 온 신입인가?",
            "우리가 계획 중인 일이 있는데 부탁 하나 들어주면 너도 끼워주도록 하지.",
            "우리 동료가 갇혀있는 방의 열쇠를 찾아서 내일까지 가져올 수 있겠나?"
        };
    }

    public new void StartDialogue()
    {
        base.StartDialogue();
        dialogueText.text = dialogues[0];
    }
    public override void OnInteract()
    {
        questManager.CompleteQuest(2);
        base.OnInteract();
    }
}
