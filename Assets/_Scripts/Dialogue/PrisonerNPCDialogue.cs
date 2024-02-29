
public class PrisonerNPCDialogue : NPCDialogue
{
    public QuestManager questManager;
    void Start()
    {
        dialogues = new string[]
        {
            "만나서 반갑네.",
            "자네에게 뭔가가 필요한거 같군.",
            "감옥 3층을 한번 찾아보게."
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               