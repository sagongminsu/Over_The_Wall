using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GardenerNPCDialogue : NPCDialogue
{
    public Transform playerTransform;
    public Transform targetLocation; // 대화가 끝난 후 이동할 목표 위치
    public Transform waitLocation; // 시간 외 대기 위치
    private NavMeshAgent agent;
    private bool hasInteracted = false;
    private int lastInteractionDay = -1;
    public Collider interactionZone; // 플레이어가 있어야 할 특정 공간

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        dialogues = new string[]
        {
            "아침시간이다. 기상!",
        };
    }

    void Update()
    {
       
        int currentDay = gameManager.I.dayNightCycle.Days;
        if (currentDay != lastInteractionDay)
        {
            hasInteracted = false; 
            lastInteractionDay = currentDay; 
        }

<<<<<<< Updated upstream
        
        if (gameManager.I.CheckTime(6, 7) && !hasInteracted)
        {
            
            agent.SetDestination(playerTransform.position);
=======
        // 현재 시간이 오전 5시에서 6시 사이인지 확인
        if (gameManager.I.CheckTime(5, 6))
        {
            // 플레이어가 interactionZone 내부에 있는지 확인
            if (!hasInteracted && interactionZone.bounds.Contains(playerTransform.position))
            {
                agent.SetDestination(playerTransform.position);
            }
>>>>>>> Stashed changes
        }

       
        if (hasInteracted)
        {
<<<<<<< Updated upstream
            agent.SetDestination(targetLocation.position); 
=======
            // 그 외의 시간에는 waitLocation 위치로 이동
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.SetDestination(waitLocation.position);
            }
>>>>>>> Stashed changes
        }
    }

    public new void StartDialogue()
    {
        base.StartDialogue();
        dialogueText.text = dialogues[0];
        hasInteracted = true; // 대화를 시작하면 상호작용했다고 표시
    }

    public override void OnInteract()
    {
        base.OnInteract();
<<<<<<< Updated upstream
=======
        // 대화가 시작되면, hasInteracted를 true로 설정하여 해당 날짜에 다시 상호작용하지 않도록 함
        hasInteracted = true;
>>>>>>> Stashed changes
    }

    protected override void EndDialogue()
    {
        base.EndDialogue();
<<<<<<< Updated upstream
=======
        // 대화가 끝나면, NPC는 targetLocation으로 이동
        agent.SetDestination(targetLocation.position);
>>>>>>> Stashed changes
        hasInteracted = true;
    }
}