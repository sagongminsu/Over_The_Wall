using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPatrollingState : AiBaseState
{
    private readonly List<Transform> waypoints;
    private int currentWaypointIndex;

    public AiPatrollingState(AiStateMachine stateMachine, List<Transform> waypoints) : base(stateMachine)
    {
        this.waypoints = waypoints;
        currentWaypointIndex = 0;
    }

    public override void Enter()
    {
        base.Enter();
        MoveToNextWaypoint();
    }

    public override void Update()
    {
        if (waypoints.Count == 0)
        {
            
            return;
        }

        if (Vector3.Distance(stateMachine.Ai.transform.position, waypoints[currentWaypointIndex].position) < 1f)
        {
            
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        }

       
        MoveToNextWaypoint();
    }

    private void MoveToNextWaypoint()
    {
        
        if (currentWaypointIndex >= 0 && currentWaypointIndex < waypoints.Count)
        {
            stateMachine.Ai.Agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }
}