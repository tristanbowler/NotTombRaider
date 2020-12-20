using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenController : MonoBehaviour
{
    public Transform[] spawnPoints;
    private GameObject targetPlayer;
    private HealthContorller player1;
    private HealthContorller player2;
    private Animator animator;
    private EnemyParticleController particles;
    public float attackCoolDownTime = 2;
    private bool attackAvailable = true;
    public GameObject bomb;
    private int attackRange;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        particles = this.gameObject.GetComponent<EnemyParticleController>();
        particles.Spawn();
        player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<HealthContorller>();
        player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<HealthContorller>();
        
    }


    private void GetTarget()
    {
        if (Vector3.Distance(this.transform.position, player1.gameObject.transform.position) <= Vector3.Distance(this.transform.position, player2.gameObject.transform.position))
        {
            if (!player1.isDead)
            {
                targetPlayer = player1.gameObject;
            }
            else if (!player2.isDead)
            {
                targetPlayer = player2.gameObject;
            }
            else
            {
                targetPlayer = null;
            }

            //Debug.Log("Closest Player: player 1");
        }
        else
        {
            if (!player2.isDead)
            {
                targetPlayer = player2.gameObject;
            }
            else if (!player1.isDead)
            {
                targetPlayer = player1.gameObject;
            }
            else
            {
                targetPlayer = null;
            }
        }
    }

    private IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(attackCoolDownTime);
        attackAvailable = true;
        if (targetPlayer != null)
        {
            //animator.SetBool("isWalk", true);
        }
    }

    private void CheckAttack()
    {
        if ((Vector3.Distance(this.transform.position, targetPlayer.transform.position) > attackRange ) && attackAvailable)
        {
            int rand = Random.Range(0, 3);
            if(rand == 1)
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

    private void CheckRespawn()
    {
        if ((Vector3.Distance(this.transform.position, targetPlayer.transform.position) > attackRange) && attackAvailable)
        {
            int rand = Random.Range(0, 3);
            if (rand == 1)
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
