using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBehavior : MonoBehaviour
{
    private DayNightCycle dayNightCycle;
    private NavMeshAgent agent;
    public Transform playerTransform; 
    public Transform nextWaypoint; // ��ȭ �� NPC�� �̵��� ���� ��ġ

    private void Start()
    {
        dayNightCycle = FindObjectOfType<DayNightCycle>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        ApproachPlayerInMorning();
    }

    private void ApproachPlayerInMorning()
    {
        if (dayNightCycle != null)
        {
            int currentHour = dayNightCycle.Hours;

            // ��ħ �ð�(��: 6�ú��� 9�� ����)���� �÷��̾�� ����
            if (currentHour >= 6 && currentHour <= 9)
            {
                agent.SetDestination(playerTransform.position);

                // �÷��̾���� �Ÿ��� ����� ������ ��ȭ ���� (����)
                if (Vector3.Distance(transform.position, playerTransform.position) < 2f)
                {
                    StartInteraction();
                }
            }
        }
    }

    private void StartInteraction()
    {
        // �÷��̾���� ��ȣ�ۿ� ���� ���� (��ȭ ���� ��)
        // ��ȣ�ۿ��� ������ ���� ��ġ�� �̵�
        MoveToNextLocation();
    }

    private void MoveToNextLocation()
    {
        if (nextWaypoint != null)
        {
            agent.SetDestination(nextWaypoint.position);
        }
    }
}
