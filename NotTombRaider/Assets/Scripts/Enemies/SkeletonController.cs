using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonController : MonoBehaviour
{
    private GameObject closestPlayer;
    private NavMeshAgent agent;
    void Start()
    {
        GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
        GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
        if(Vector3.Distance(this.transform.position, player1.transform.position) <= Vector3.Distance(this.transform.position, player2.transform.position))
        {
            closestPlayer = player1;
        }
        else
        {
            closestPlayer = player2;
        }
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(closestPlayer.transform.position);
        agent.isStopped = false;
    }

    // Update is called once per frame
    
}
