using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public class MonringCall : NPCDialogue
{
    public Transform playerTransform;
    public Transform targetLocation; // 대화가 끝난 후 이동할 목표 위치
    public Transform waitLocation; // 시간 외 대기 위치
    private NavMeshAgent agent;
    private bool hasInteracted = false;
    private int lastInteractionDay = -1;
    public Collider interactionZone; // 플레이어가 있어야 할 특정 공간
    private bool isDialogueActive = false;
    public static event Action OnDialogueEnd;

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
                if (distanceToPlayer < 0.1f) // 추가적인 거리 조건이 필요하다면 이를 확인
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
            isDialogueActive = true; // 대화가 시작되었음을 나타냄
            agent.SetDestination(targetLocation.position);
        }
    }

    public override void OnInteract()
    {
        base.OnInteract();
        // 대화가 시작되면, hasInteracted를 true로 설정하여 해당 날짜에 다시 상호작용하지 않도록 함
        hasInteracted = true;
    }

    protected override void EndDialogue()
    {
        base.EndDialogue();
        agent.SetDestination(targetLocation.position);
        hasInteracted = true;
        isDialogueActive = false; // 대화가 종료되었음을 나타냄
        OnDialogueEnd?.Invoke();
    }
}
