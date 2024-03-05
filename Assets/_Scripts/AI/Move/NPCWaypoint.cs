using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCWaypoint : MonoBehaviour
{
    public Transform[] waypoints;
    private int waypointIndex = 0;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToNextWaypoint();
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 10.5f)
        {
            MoveToNextWaypoint();
        }


    }

    void MoveToNextWaypoint()
    {
        if (waypoints == null) return;
        if (waypoints.Length == 0) return;
        agent.destination = waypoints[waypointIndex].position;
        waypointIndex = (waypointIndex + 1) % waypoints.Length;
    }
}
