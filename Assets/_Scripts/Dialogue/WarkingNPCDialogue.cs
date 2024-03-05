using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorkingNPCDialogue : NPCDialogue
{
    public Transform waypointBeforeWork;
    public Transform waypointAfterWork;
    public Transform playerTransform; // 플레이어 위치
    private NavMeshAgent agent;
    private bool hasInteracted = false;
    private int lastInteractionDay = -1;
    private float interactionDistance = 1f; // 플레이어와의 상호작용 거리

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        dialogues = new string[]
        {
            "일할 시간이야, 신입이다.",
            "돈을 벌고 싶으면 일을 해야한다",
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

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // 13시에 플레이어에게 접근
        if (gameManager.I.CheckTime(13, 14) && !hasInteracted && distanceToPlayer > interactionDistance)
        {
            agent.SetDestination(playerTransform.position);
        }
        else if (gameManager.I.CheckTime(13, 14) && !hasInteracted && distanceToPlayer <= interactionDistance)
        {
            // 플레이어와의 거리가 interactionDistance 이내일 때 대화 시작
            StartDialogue();
        }

        // 대화가 진행된 후 특정 위치로 이동
        if (hasInteracted)
        {
            agent.SetDestination(waypointBeforeWork.position);
        }

        // 15시에 다른 위치로 이동
        if (gameManager.I.CheckTime(15, 16))
        {
            agent.SetDestination(waypointAfterWork.position);
        }
    }

    public void StartDialogue()
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
