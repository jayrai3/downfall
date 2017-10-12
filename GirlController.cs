using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class GirlController : MonoBehaviour
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

    //public Transform target;
    //public float distanceToStartChasingTarget = 0.1f;

    //public int distanceToStartAttackingTarget = 7;
    //public int attackHashId;


    void Awake()
    {
        // create hashid for the "speed" param of the Animator
        speedHashId = Animator.StringToHash("walkingSpeed");

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
        //else if (type == AgentType.Patrolling) Patrol();

        //else if (type == AgentType.Chasing) Chase();
    }

    void Idle()
    {
        // TODO: stop navmesh to stop movement

        // set speed to 0 to stop anim
        animController.SetFloat(speedHashId, 0.0f);
    }

    void Patrol()
    {
        // #1 TODO: tell the navmeshagent to resume (when idling we tell it to stop)
        //navMeshAgent.Resume();

        // set Animator "speed" parameter to 1.0f to trigger walking anim
        //animController.SetFloat(speedHashId, 1.0f);
  
        //if (navMeshAgent.remainingDistance < distanceToStartHeadingToNextWaypoint)
        //{
        //    waypointId++;

            // Loop to first waypoint.
        //    if (waypointId >= waypoints.Length)
        //    {
        //        waypointId = 0;
        //    }

            // New waypoint position.
        //    navMeshAgent.SetDestination(waypoints[waypointId].position);
        
    }

    void Chase()
    {


        //Vector3 directionToTarget = navMeshAgent.nextPosition - target.position;
        //int angleToTarget;

        //float angle = Vector3.Angle(navMeshAgent.transform.forward, transform.forward);
        //angleToTarget = (int)Mathf.Abs(angle);

        //navMeshAgent.SetDestination(target.position);
        //navMeshAgent.Resume();
        //animController.SetFloat(speedHashId, 1.0f);

        //if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance || navMeshAgent.remainingDistance < distanceToStartChasingTarget || angleToTarget > 90)
        //{
        //    if (navMeshAgent.remainingDistance < distanceToStartAttackingTarget)
        //   {
        //        Attack();
        //    }

        //    Idle();
        //}

        //else
        //{
        //   navMeshAgent.Resume();
        //   animController.SetFloat(speedHashId, 1.0f);
        //}
    }

    //void Attack()
    //{
    //    animController.SetTrigger(attackHashId);
    //}

}
