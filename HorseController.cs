using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class HorseController : MonoBehaviour
{ 
    // the types of agent we will have
    public enum AgentType
    {
        Idle = 0,
        Patrolling,
        Chasing
    }

    // what type is this agent?
    public AgentType type;

    // the waypoints the agent will follow 
    public Transform[] waypoints;
    public float distanceToStartHeadingToNextWaypoint = 1;
    private int waypointId = 0;

    // NavmeshAgent reference
    public NavMeshAgent navMeshAgent;

    // animator reference and hashid for walkingSpeed parameter
    public Animator animController;
    private int speedHashId;

    void Awake()
    {
        // create hashid for the "speed" param of the Animator
        speedHashId = Animator.StringToHash("Horse_Walk");

        // if no waypoints have been assigned (so many students forget to do this so this will throw an informative error for you!
        if (waypoints.Length == 0)
        {
            Debug.LogError("ARGHHHHHHHH!!! You need to assign some waypoints within the Inspector!");
            enabled = false;
            return;
        }

    }

    void Update()
    {
        if (type == AgentType.Idle) Idle();

        // If horse is patrolling.
        else if (type == AgentType.Patrolling) Patrol();
    }

    void Idle()
    {
        // TODO: stop navmesh to stop movement
        navMeshAgent.Stop();

        // set speed to 0 to stop anim
        //animController.SetFloat(speedHashId, 0.0f);
    }

    void Patrol()
    {
        // Horse starts walking.
        navMeshAgent.Resume();

        // set Animator "speed" parameter to 1.0f to trigger walking anim
        //animController.SetFloat(speedHashId, 1.0f);
    
        if (navMeshAgent.remainingDistance < distanceToStartHeadingToNextWaypoint)
        {
            // Go to next waypoint.
            waypointId++;

            // Loop to first waypoint.
            if (waypointId >= waypoints.Length)
            {
                waypointId = 0;
            }

            // New waypoint position.
            navMeshAgent.SetDestination(waypoints[waypointId].position);
        }
    }
}