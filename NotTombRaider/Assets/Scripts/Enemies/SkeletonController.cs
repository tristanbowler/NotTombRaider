using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonController : EnemyController
{
    private GameObject closestPlayer;
    public NavMeshAgent agent;
    private GameObject player1;
    private GameObject player2;
    public MacheteController machete;
    public float attackCoolDownTime = 2;
    private bool attackAvailable = true;
    void Start()
    {
        
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
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

    private IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(attackCoolDownTime);
        attackAvailable = true;

    }
    private void CheckMachete()
    {
        if((Vector3.Distance(this.transform.position, closestPlayer.transform.position) < 2 * agent.stoppingDistance) && attackAvailable)
        {
            machete.Swing();
            attackAvailable = false;
            StartCoroutine(AttackCoolDown());
        }
    }


    private void Update()
    {
        if (Vector3.Distance(this.transform.position, player1.transform.position) <= Vector3.Distance(this.transform.position, player2.transform.position))
        {
            closestPlayer = player1;
            Debug.Log("Closest Player: player 1");
        }
        else
        {
            closestPlayer = player2;
            Debug.Log("Closest Player: player 2");
        }
        
        agent.destination = closestPlayer.transform.position;
        agent.SetDestination(closestPlayer.transform.position);
        CheckMachete();
    }
    // Update is called once per frame

    

}
