using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCRandomMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public float patrolTime = 10f;
    private float elapsed;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        elapsed = patrolTime;
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= patrolTime)
        {
            elapsed = 0;
            Vector3 newDestination = RandomNavSphere(transform.position, 20f, -1);
            agent.SetDestination(newDestination);
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);
        return navHit.position;
    }
}
