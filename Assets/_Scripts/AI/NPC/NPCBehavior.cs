using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBehavior : MonoBehaviour
{
    private DayNightCycle dayNightCycle;
    private NavMeshAgent agent;
    public Transform playerTransform; 
    public Transform nextWaypoint; 

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

           
            if (currentHour >= 6 && currentHour <= 7)
            {
                agent.SetDestination(playerTransform.position);

               
                if (Vector3.Distance(transform.position, playerTransform.position) < 2f)
                {
                    StartInteraction();
                }
            }
        }
    }

    private void StartInteraction()
    {

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
