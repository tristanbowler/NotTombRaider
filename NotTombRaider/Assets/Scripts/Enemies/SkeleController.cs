using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeleController : MonoBehaviour
{
    public enum WeaponType
    {
        Unarmed,
        Sword,
        Archer
    }

    public WeaponType weaponType;
    public int attackRange = 2;
    private GameObject targetPlayer;
    private NavMeshAgent agent;
    private GameObject player1;
    private GameObject player2;
    private Animator animator;
    private EnemyParticleController particles;
    //public MacheteController machete;
    public float attackCoolDownTime = 2;
    private bool attackAvailable = true;
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        particles = this.gameObject.GetComponent<EnemyParticleController>();
        particles.Spawn();
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");

        if (agent == null)
        {
            agent = this.GetComponent<NavMeshAgent>();
        }

        GetTarget();

        
        animator.SetBool("isWalk", true);
        agent.enabled = true;
        agent.destination = targetPlayer.transform.position;
        agent.isStopped = false;
        agent.SetDestination(targetPlayer.transform.position);

    }

    private void GetTarget()
    {
        if(weaponType == WeaponType.Archer)
        {
            if (Vector3.Distance(this.transform.position, player1.transform.position) >= Vector3.Distance(this.transform.position, player2.transform.position))
            {
                targetPlayer = player1;
                //Debug.Log("Closest Player: player 1");
            }
            else
            {
                targetPlayer = player2;
                //Debug.Log("Closest Player: player 2");
            }
        }
        else
        {
            if (Vector3.Distance(this.transform.position, player1.transform.position) <= Vector3.Distance(this.transform.position, player2.transform.position))
            {
                targetPlayer = player1;
                //Debug.Log("Closest Player: player 1");
            }
            else
            {
                targetPlayer = player2;
                //Debug.Log("Closest Player: player 2");
            }
        }
        if (agent!=null && agent.enabled)
        {
            agent.destination = targetPlayer.transform.position;
            agent.SetDestination(targetPlayer.transform.position);
        }
        
    }
    private IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(attackCoolDownTime);
        attackAvailable = true;
        animator.SetBool("isWalk", true);
        agent.enabled = true;
        agent.destination = targetPlayer.transform.position;
        agent.isStopped = false;
        agent.SetDestination(targetPlayer.transform.position);

    }
    private void CheckAttack()
    {
        if ((Vector3.Distance(this.transform.position, targetPlayer.transform.position) < attackRange * agent.stoppingDistance) && attackAvailable)
        {
            int rand = Random.Range(0, 21);
            //if(rand < 7)
            {
                //machete.Swing();
                //animator.SetBool("isWalk", false);
                animator.SetBool("isAttack", true);
                
                attackAvailable = false;
                StartCoroutine(AttackCoolDown());
                //agent.isStopped = true;
                //agent.enabled = false;
            }
            
        }
    }


    private void Update()
    {
        GetTarget();

        
        
        if(Vector3.Distance(this.transform.position, targetPlayer.transform.position) <= agent.stoppingDistance )
        {
            animator.SetBool("isWalk", false);
            transform.LookAt(targetPlayer.transform);
        }
        if (!attackAvailable)
        {

            //animator.SetBool("isWalk", false);
        }
        else
        {
            animator.SetBool("isWalk", true);
            //transform.LookAt(targetPlayer.transform);
            //agent.isStopped = false;
           
        }
        CheckAttack();
    }
    // Update is called once per frame



}
