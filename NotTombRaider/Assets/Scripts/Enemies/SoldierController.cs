using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SoldierController : MonoBehaviour
{
    
       

        public int attackRange = 2;
        private GameObject targetPlayer;
        private NavMeshAgent agent;
        private HealthContorller player1;
        private HealthContorller player2;
        private Animator animator;
        private EnemyParticleController particles;
        public GunController gun;
        public float attackCoolDownTime = 2;
        public float attackTime = 2;
        private bool attackAvailable = true;
        void Start()
        {
            animator = this.gameObject.GetComponent<Animator>();
            particles = this.gameObject.GetComponent<EnemyParticleController>();
            particles.Spawn();
            player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<HealthContorller>();
            player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<HealthContorller>();

            if (agent == null)
            {
                agent = this.GetComponent<NavMeshAgent>();
            }

            agent.enabled = true;
            GetTarget();
            if (targetPlayer != null)
            {
                animator.SetBool("isWalk", true);
                agent.isStopped = false;
            }



            //agent.destination = targetPlayer.transform.position;

            //agent.SetDestination(targetPlayer.transform.position);

        }

        private void GetTarget()
        {
           
                //Debug.Log(player1.gameObject.transform.position);
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
            
            if (targetPlayer != null)
            {
                agent.destination = targetPlayer.transform.position;
                agent.SetDestination(targetPlayer.transform.position);
            }
            else
            {
                agent.SetDestination(gameObject.transform.position);
                agent.destination = gameObject.transform.position;
            }

            if (targetPlayer == player1.gameObject)
            {
                // Debug.Log("Player 1 is target");
            }
            else if (targetPlayer == player2.gameObject)
            {
                //Debug.Log("Player 2 is target");
            }
            else
            {
                Debug.Log("Both Players are dead. No target");
            }
        }
        private IEnumerator AttackCoolDown()
        {
            yield return new WaitForSeconds(attackTime);
            gun.FireBullet();
            gun.fireParticles.SetActive(true);
        yield return new WaitForSeconds(attackCoolDownTime);
            attackAvailable = true;
            if (targetPlayer != null)
            {
                animator.SetBool("isWalk", true);
                agent.enabled = true;
                agent.destination = targetPlayer.transform.position;
                agent.isStopped = false;
                agent.SetDestination(targetPlayer.transform.position);
            }


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


            if (targetPlayer != null)
            {
                if (Vector3.Distance(this.transform.position, targetPlayer.transform.position) <= agent.stoppingDistance)
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


        }
        // Update is called once per frame



    }


