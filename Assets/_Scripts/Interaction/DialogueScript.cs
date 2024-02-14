using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    [SerializeField] private NPCInteraction npcInteraction;

    private void Start()
    {
        string[] dialogues = new string[]
        {
            "첫 번째 대화",
            "두 번째 대화",
            "세 번째 대화",
            // 필요한 만큼 대화를 추가가능
        };

        npcInteraction.GetDialogues(dialogues);
    }
}