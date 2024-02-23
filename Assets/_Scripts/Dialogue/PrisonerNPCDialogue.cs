
public class PrisonerNPCDialogue : NPCDialogue
{
    public QuestManager questManager;
    void Start()
    {
        dialogues = new string[]
        {
            
            "�츮�� ��ȹ ���� ���� �ִµ� ��Ź �ϳ� ����ָ� �ʵ� �����ֵ��� ����.",
            "�츮 ���ᰡ �����ִ� ���� ���踦 ã�Ƽ� ���ϱ��� ������ �� �ְڳ�?"
        };
    }

    public new void StartDialogue()
    {
        base.StartDialogue();
        dialogueText.text = dialogues[0];
    }
    public new void OnInteract()
    {
        questManager.CompleteQuest(1);
        base.OnInteract();
    }
}
