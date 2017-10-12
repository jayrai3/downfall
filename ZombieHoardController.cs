//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class ZombieHoardController : MonoBehaviour {


//    public Transform target;
//    private Animator myAnimator;

//    public float delayBetweenAttacks = 1.5f;
//    private float attackCooldown;

//    public int damage = 1;
//    private PlayerHealth playerHealth;

//    // Use this for initialization
//    void Start ()
//    {
//        myAnimator = GetComponent<Animator>();

//        attackCooldown = Time.time;
//        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
//    }

//	// Update is called once per frame
//	void Update ()
//    {
//        if (Vector3.Distance(target.position, this.transform.position) < 20)
//        {
//            Vector3 direction = target.position - this.transform.position;
//            direction.y = 0;

//            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

//            myAnimator.SetBool("isIdle", false);

//            if (direction.magnitude > 2)
//            {
//                this.transform.Translate(0, 0, 0.05f);
//                myAnimator.SetBool("isWalking", true);
//                myAnimator.SetBool("isAttacking", false);
//            }
//            else
//            {
//                //myAnimator.SetBool("isAttacking", true);
//                myAnimator.SetBool("isWalking", false);

//                //playerHealth.TakeDamage(damage);
//                Attack();
//            }
//        }
//        else
//        {
//            myAnimator.SetBool("isIdle", true);
//            myAnimator.SetBool("isWalking", false);
//            myAnimator.SetBool("isAttacking", false);
//        }
//    }

//    void Attack()
//    {
//        if (Time.time > attackCooldown)
//        {
//            myAnimator.SetBool("isAttacking", true);
//            attackCooldown = Time.time + delayBetweenAttacks;

//            playerHealth.TakeDamage(damage);
//        }
//    }
//}


using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class ZombieHoardController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Transform target;

    private Animator myAnimator;
    public bool chaseTarget = true;
    public float stoppingDistance = 2.5f;
    public float delayBetweenAttacks = 1.5f;
    private float attackCooldown;

    private float distanceFromTarget;

    public int damage = 10;
    private PlayerHealth playerHealth;

    // Use this for initialization
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        myAnimator = GetComponent<Animator>();

        navMeshAgent.stoppingDistance = stoppingDistance;
        attackCooldown = Time.time;

        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, this.transform.position) < 15)
        {
            Vector3 direction = target.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            ChaseTarget();
        }

        else
        {
            myAnimator.SetBool("isIdle", true);

            //Turn running off
            myAnimator.SetBool("isChasing", false);
            chaseTarget = false;
        }
    }

    void ChaseTarget()
    {
        distanceFromTarget = Vector3.Distance(target.position, transform.position);

        if (distanceFromTarget >= stoppingDistance)
        {
            chaseTarget = true;
        }
        else
        {
            chaseTarget = false;
            Attack();
        }

        if (chaseTarget)
        {
            navMeshAgent.SetDestination(target.position);
            myAnimator.SetBool("isChasing", true);
        }
        else
        {
            myAnimator.SetBool("isChasing", false);
        }
    }

    void Attack()
    {
        if (Time.time > attackCooldown)
        {
            playerHealth.TakeDamage(damage);

            myAnimator.SetTrigger("Attack");
            attackCooldown = Time.time + delayBetweenAttacks;
        }
    }

}