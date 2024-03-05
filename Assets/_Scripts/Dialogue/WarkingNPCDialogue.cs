using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorkingNPCDialogue : NPCDialogue
{
    public Transform waypointBeforeWork;
    public Transform waypointAfterWork;
    public Transform playerTransform; // �÷��̾� ��ġ
    private NavMeshAgent agent;
    private bool hasInteracted = false;
    private int lastInteractionDay = -1;
    private float interactionDistance = 1f; // �÷��̾���� ��ȣ�ۿ� �Ÿ�

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        dialogues = new string[]
        {
            "���� �ð��̾�, �����̴�.",
            "���� ���� ������ ���� �ؾ��Ѵ�",
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

        // 13�ÿ� �÷��̾�� ����
        if (gameManager.I.CheckTime(13, 14) && !hasInteracted && distanceToPlayer > interactionDistance)
        {
            agent.SetDestination(playerTransform.position);
        }
        else if (gameManager.I.CheckTime(13, 14) && !hasInteracted && distanceToPlayer <= interactionDistance)
        {
            // �÷��̾���� �Ÿ��� interactionDistance �̳��� �� ��ȭ ����
            StartDialogue();
        }

        // ��ȭ�� ����� �� Ư�� ��ġ�� �̵�
        if (hasInteracted)
        {
            agent.SetDestination(waypointBeforeWork.position);
        }

        // 15�ÿ� �ٸ� ��ġ�� �̵�
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
