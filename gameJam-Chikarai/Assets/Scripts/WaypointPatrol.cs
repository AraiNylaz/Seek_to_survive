using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    private int _currentWaypointIndex;
    [SerializeField] private Animator animator;
    
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update()
    {

        StartCoroutine(WayPoints());

    }

    IEnumerator WayPoints()
    {
        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination (waypoints[_currentWaypointIndex].position);
            animator.SetBool("IsWalking", false);
            
            navMeshAgent.Stop();
            yield return new WaitForSeconds(3f);
            navMeshAgent.Resume();
            animator.SetBool("IsWalking", true);
            
        }
        
    }
}
