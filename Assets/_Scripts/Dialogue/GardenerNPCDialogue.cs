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

        // ���� �ð��� ���� 6�ÿ��� 7�� �������� Ȯ��
        if (gameManager.I.CheckTime(6, 7))
        {
            // ���� ��ȣ�ۿ����� �ʾҴٸ� �÷��̾� ��ġ�� �̵�
            if (!hasInteracted)
            {
                agent.SetDestination(playerTransform.position);
            }
        }
        else
        {
            // �� ���� �ð����� targetLocation ��ġ�� �̵�
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
