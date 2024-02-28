using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBehavior : MonoBehaviour
{
    private DayNightCycle dayNightCycle;
    private NavMeshAgent agent;
    public Transform playerTransform; 
    public Transform nextWaypoint; // 대화 후 NPC가 이동할 다음 위치

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

            // 아침 시간(예: 6시부터 9시 사이)에만 플레이어에게 접근
            if (currentHour >= 6 && currentHour <= 9)
            {
                agent.SetDestination(playerTransform.position);

                // 플레이어와의 거리가 충분히 가까우면 대화 시작 (가정)
                if (Vector3.Distance(transform.position, playerTransform.position) < 2f)
                {
                    StartInteraction();
                }
            }
        }
    }

    private void StartInteraction()
    {
        // 플레이어와의 상호작용 로직 구현 (대화 시작 등)
        // 상호작용이 끝나면 다음 위치로 이동
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
