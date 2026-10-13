using UnityEngine;
using UnityEngine.AI;

// Prototype AI for an offline practice opponent.
// Requires a baked NavMesh and a NavMeshAgent component.
[RequireComponent(typeof(NavMeshAgent))]
public class BotPatrolAI : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float arriveDistance = 1.4f;
    [SerializeField] private float pauseAtPoint = 0.8f;
    [SerializeField] private float retargetInterval = 2.5f;

    private NavMeshAgent agent;
    private int currentPoint = -1;
    private float pauseUntil;
    private float nextRetarget;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        ChooseNextPoint();
    }

    private void Update()
    {
        if (patrolPoints == null || patrolPoints.Length == 0 || agent == null || !agent.isOnNavMesh)
            return;

        if (Time.time < pauseUntil) return;

        bool arrived = !agent.pathPending &&
                       agent.remainingDistance <= Mathf.Max(arriveDistance, agent.stoppingDistance);

        if (arrived || Time.time >= nextRetarget)
        {
            pauseUntil = Time.time + pauseAtPoint;
            ChooseNextPoint();
        }
    }

    private void ChooseNextPoint()
    {
        if (patrolPoints == null || patrolPoints.Length == 0 || agent == null) return;

        int next = currentPoint;
        if (patrolPoints.Length > 1)
        {
            int attempts = 0;
            while (next == currentPoint && attempts++ < 8)
                next = Random.Range(0, patrolPoints.Length);
        }
        else next = 0;

        currentPoint = next;
        Transform point = patrolPoints[currentPoint];
        if (point != null && agent.isOnNavMesh)
        {
            agent.SetDestination(point.position);
            nextRetarget = Time.time + retargetInterval;
        }
    }
}
