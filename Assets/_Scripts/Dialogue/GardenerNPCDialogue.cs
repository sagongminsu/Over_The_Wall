using UnityEngine.AI;
using UnityEngine;

public class GardenerNPCDialogue : NPCDialogue
{
    public Transform playerTransform; // 플레이어 위치 참조
    public Transform targetLocation; // AI가 이동할 대상 위치
    private NavMeshAgent agent; // NavMeshAgent 참조
    private bool hasInteracted = false;
    private int lastInteractionDay = -1; // 마지막 상호작용이 발생한 날짜

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        dialogues = new string[]
        {
            "아침시간이다. 기상!",
            "1."
        };
    }

    void Update()
    {
       
        int currentDay = gameManager.I.dayNightCycle.Days;
        if (currentDay != lastInteractionDay)
        {
            hasInteracted = false; // 매일 리셋
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