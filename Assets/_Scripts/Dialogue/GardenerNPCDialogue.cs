using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GardenerNPCDialogue : NPCDialogue
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

<<<<<<< Updated upstream
        
        if (gameManager.I.CheckTime(6, 7) && !hasInteracted)
        {
            
            agent.SetDestination(playerTransform.position);
=======
        // ���� �ð��� ���� 5�ÿ��� 6�� �������� Ȯ��
        if (gameManager.I.CheckTime(5, 6))
        {
            // �÷��̾ interactionZone ���ο� �ִ��� Ȯ��
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
            // �� ���� �ð����� waitLocation ��ġ�� �̵�
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
        hasInteracted = true; // ��ȭ�� �����ϸ� ��ȣ�ۿ��ߴٰ� ǥ��
    }

    public override void OnInteract()
    {
        base.OnInteract();
<<<<<<< Updated upstream
=======
        // ��ȭ�� ���۵Ǹ�, hasInteracted�� true�� �����Ͽ� �ش� ��¥�� �ٽ� ��ȣ�ۿ����� �ʵ��� ��
        hasInteracted = true;
>>>>>>> Stashed changes
    }

    protected override void EndDialogue()
    {
        base.EndDialogue();
<<<<<<< Updated upstream
=======
        // ��ȭ�� ������, NPC�� targetLocation���� �̵�
        agent.SetDestination(targetLocation.position);
>>>>>>> Stashed changes
        hasInteracted = true;
    }
}