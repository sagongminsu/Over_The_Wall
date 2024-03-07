using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public class MonringCall : NPCDialogue
{
    public Transform playerTransform;
    public Transform targetLocation; // ��ȭ�� ���� �� �̵��� ��ǥ ��ġ
    public Transform waitLocation; // �ð� �� ��� ��ġ
    private NavMeshAgent agent;
    private bool hasInteracted = false;
    private int lastInteractionDay = -1;
    public Collider interactionZone; // �÷��̾ �־�� �� Ư�� ����
    private bool isDialogueActive = false;
    public static event Action OnDialogueEnd;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        dialogues = new string[]
        {
            "��ħ�ð��̴�. ���!",
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

        if (isDialogueActive && Input.GetKeyDown(KeyCode.E))
        {
            EndDialogue();
            return;
        }

        if (gameManager.I.CheckTime(6, 7) && !hasInteracted)
        {

            if (TriggerDetector.playerIsInTrigger)
            {
                float distanceToPlayer = Vector3.Distance(playerTransform.position, this.transform.position);
                if (distanceToPlayer < 0.1f) // �߰����� �Ÿ� ������ �ʿ��ϴٸ� �̸� Ȯ��
                {
                    StartDialogue();
                }
                else if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
                {
                    agent.SetDestination(playerTransform.position);
                }
            }
        }
        else
        {
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.SetDestination(waitLocation.position);
            }
        }
    }

    public new void StartDialogue()
    {
        if (!hasInteracted)
        {
            base.StartDialogue();
            dialogueText.text = dialogues[0];
            hasInteracted = true;
            isDialogueActive = true; // ��ȭ�� ���۵Ǿ����� ��Ÿ��
            agent.SetDestination(targetLocation.position);
        }
    }

    public override void OnInteract()
    {
        base.OnInteract();
        // ��ȭ�� ���۵Ǹ�, hasInteracted�� true�� �����Ͽ� �ش� ��¥�� �ٽ� ��ȣ�ۿ����� �ʵ��� ��
        hasInteracted = true;
    }

    protected override void EndDialogue()
    {
        base.EndDialogue();
        agent.SetDestination(targetLocation.position);
        hasInteracted = true;
        isDialogueActive = false; // ��ȭ�� ����Ǿ����� ��Ÿ��
        OnDialogueEnd?.Invoke();
    }
}
