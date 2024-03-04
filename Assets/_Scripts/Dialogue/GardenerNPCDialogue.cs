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
