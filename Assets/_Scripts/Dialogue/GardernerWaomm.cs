using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GardernerWaomm : NPCDialogue
{
    public Transform playerTransform;
    public Transform targetLocation; // ��ȭ�� ���� �� �̵��� ��ǥ ��ġ
    public Transform waitLocation; // �ð� �� ��� ��ġ
    private NavMeshAgent agent;
    private bool hasInteracted = false;
    private int lastInteractionDay = -1;
    public Collider interactionZone; // �÷��̾ �־�� �� Ư�� ����

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        dialogues = new string[]
        {
            "��ȣ�ð��̴�. ��� �ڸ���!",
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

        // ���� �ð��� ���� 21�ÿ��� 22�� �������� Ȯ��
        if (gameManager.I.CheckTime(21, 22))
        {
            // �÷��̾ interactionZone ���ο� �ִ��� Ȯ��
            if (!hasInteracted && interactionZone.bounds.Contains(playerTransform.position))
            {
                agent.SetDestination(playerTransform.position);
            }
        }
        else
        {
            // �� ���� �ð����� waitLocation ��ġ�� �̵�
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.SetDestination(waitLocation.position);
            }
        }
    }

    public new void StartDialogue()
    {
        base.StartDialogue();
        dialogueText.text = dialogues[0];
        hasInteracted = true; // ��ȭ�� �����ϸ� ��ȣ�ۿ��ߴٰ� ǥ��
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
        // ��ȭ�� ������, NPC�� targetLocation���� �̵�
        agent.SetDestination(targetLocation.position);
        hasInteracted = true;
    }
}
