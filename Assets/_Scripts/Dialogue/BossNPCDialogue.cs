
public class BossNPCDialogue : NPCDialogue
{
    public QuestManager questManager;
    void Start()
    {
        dialogues = new string[]
        {
            "�̹��� �� �����ΰ�?",
            "�츮�� ��ȹ ���� ���� �ִµ� ��Ź �ϳ� ����ָ� �ʵ� �����ֵ��� ����.",
            "�츮 ���ᰡ �����ִ� ���� ���踦 ã�Ƽ� ���ϱ��� ������ �� �ְڳ�?"
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
