
public class PrisonerNPCDialogue : NPCDialogue
{
    public QuestManager questManager;
    void Start()
    {
        dialogues = new string[]
        {
            "������ �ݰ���.",
            "�ڳ׿��� ������ �ʿ��Ѱ� ����.",
            "���� 3���� �ѹ� ã�ƺ���."
        };
    }

    public new void StartDialogue()
    {
        base.StartDialogue();
        dialogueText.text = dialogues[0];
    }
    public override void OnInteract()
    {
        questManager.CompleteQuest(1);
        base.OnInteract();
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               