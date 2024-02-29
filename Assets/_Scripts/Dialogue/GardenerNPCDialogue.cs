using UnityEngine.AI;
using UnityEngine;

public class GardenerNPCDialogue : NPCDialogue
{
    public Transform playerTransform; // �÷��̾� ��ġ ����
    public Transform targetLocation; // AI�� �̵��� ��� ��ġ
    private NavMeshAgent agent; // NavMeshAgent ����
    private bool hasInteracted = false;
    private int lastInteractionDay = -1; // ������ ��ȣ�ۿ��� �߻��� ��¥

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        dialogues = new string[]
        {
            "��ħ�ð��̴�. ���!",
            "1."
        };
    }

    void Update()
    {
       
        int currentDay = gameManager.I.dayNightCycle.Days;
        if (currentDay != lastInteractionDay)
        {
            hasInteracted = false; // ���� ����
            lastInteractionDay = currentDay; 
        }

       
        if (gameManager.I.CheckTime(6, 7) && !hasInteracted)
        {
           
            agent.SetDestination(playerTransform.position);
        }

    
        if (hasInteracted)
        {
            agent.SetDestination(targetLocation.position); 
        }
    }

    public new void StartDialogue()
    {
        base.StartDialogue();
        dialogueText.text = dialogues[0];
    }

    public override void OnInteract()
    {
        base.OnInteract();
    }

    protected override void EndDialogue()
    {
        base.EndDialogue();
        hasInteracted = true;
    }
}