using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonController : EnemyController
{
    private GameObject closestPlayer;
    public NavMeshAgent agent;
    void Start()
    {
        
        GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
        GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
        if(Vector3.Distance(this.transform.position, player1.transform.position) <= Vector3.Distance(this.transform.position, player2.transform.position))
        {
            closestPlayer = player1;
            Debug.Log("Closest Player: player 1");
        }
        else
        {
            closestPlayer = player2;
            Debug.Log("Closest Player: player 2");
        }
        if(agent == null)
        {
            agent = this.GetComponent<NavMeshAgent>();
        }

        agent.enabled = true;
        agent.destination = closestPlayer.transform.position;
        agent.isStopped = false;
        agent.SetDestination(closestPlayer.transform.position);
    }

    // Update is called once per frame
    
}
