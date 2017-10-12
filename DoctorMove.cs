using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoctorMove : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;
    private Animator myAnimator;

    public int moveSpeed = 4;
    public int minDist = 5;
    public int maxDist = 10;

    public AudioSource scareSound;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.LookAt(player);

        if(Vector3.Distance(transform.position, player.position) < 40) 
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;

            myAnimator.SetBool("isRunning", true);

            if(Vector3.Distance(transform.position, player.position) <= minDist)
            {
                scareSound.Play();

                //Destroy Character
                Destroy(gameObject);
            }
        }
    }
}