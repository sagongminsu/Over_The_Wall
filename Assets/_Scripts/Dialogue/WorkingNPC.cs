using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class WorkingNPC : NPCDialogue
{
    public Transform waypointBeforeWork;
    public Transform waypointAfterWork;
    private NavMeshAgent agent;
    private bool hasInteractedToday = false;
    private int lastInteractionDay = -1;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        dialogues = new string[]
        {
            "돈이 필요해",
            
        };
    }

    void Update()
    {
        int currentDay = gameManager.I.dayNightCycle.Days;
        if (currentDay != lastInteractionDay)
        {
            hasInteractedToday = false;
            lastInteractionDay = currentDay;
        }

        // 시간에 따라 위치 결정
        DeterminePositionByTime();
    }

    void DeterminePositionByTime()
    {
        if (gameManager.I.CheckTime(13, 14) && !hasInteractedToday)
        {
            agent.SetDestination(waypointBeforeWork.position);
        }
        else if (gameManager.I.CheckTime(15, 16))
        {
            agent.SetDestination(waypointAfterWork.position);
        }
    }

    public override void OnInteract()
    {
        if (!hasInteractedToday)
        {
            StartDialogue();
        }
    }

    public void StartDialogue()
    {
        base.StartDialogue();
        dialogueText.text = dialogues[0];
        hasInteractedToday = true;
    }

    protected override void EndDialogue()
    {
        base.EndDialogue();
        
    }
}