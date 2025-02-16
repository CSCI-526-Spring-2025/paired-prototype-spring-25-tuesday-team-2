using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform[] patrolPoints; // Assign patrol waypoints in Inspector
    private int currentPoint = 0;
    private NavMeshAgent agent;

    public Transform player; // Assign Player in Inspector
    public float chaseDistance = 5f; // Distance to start chasing
    public float escapeBuffer = 3f; // Additional buffer before stopping chase
    private bool isChasing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToNextPoint();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < chaseDistance)
        {
            // Start chasing the player
            isChasing = true;
            agent.speed = 5f; // Faster when chasing
            agent.destination = player.position;
        }
        else if (isChasing && distanceToPlayer > chaseDistance + escapeBuffer)
        {
            // Player escaped, return to patrol
            isChasing = false;
            MoveToNextPoint();
        }

        // Continue patrolling if not chasing
        if (!isChasing && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            MoveToNextPoint();
        }
    }

    void MoveToNextPoint()
    {
        if (patrolPoints.Length == 0) return;

        agent.speed = 3.5f; // Normal patrol speed
        agent.destination = patrolPoints[currentPoint].position;
        currentPoint = (currentPoint + 1) % patrolPoints.Length;
    }
}
