using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GardenerNPCDialogue : NPCDialogue
{
    public Transform playerTransform; 
    public Transform targetLocation; 
    private NavMeshAgent agent; 
    private bool hasInteracted = false;
    private int lastInteractionDay = -1; 

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

        // 현재 시간이 오전 6시에서 7시 사이인지 확인
        if (gameManager.I.CheckTime(6, 7))
        {
            // 아직 상호작용하지 않았다면 플레이어 위치로 이동
            if (!hasInteracted)
            {
                agent.SetDestination(playerTransform.position);
            }
        }
        else
        {
            // 그 외의 시간에는 targetLocation 위치로 이동
            if (!agent.pathPending && (agent.remainingDistance <= agent.stoppingDistance))
            {
                agent.SetDestination(targetLocation.position);
            }
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
        hasInteracted = true; 
    }

    protected override void EndDialogue()
    {
        base.EndDialogue();
        hasInteracted = true; 
    }
}
