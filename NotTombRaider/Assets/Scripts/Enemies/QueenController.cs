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
    public float attacktime = 3;
    public float respawnCoolDownTime = 10;
    public float respawnTime = 6;
    private bool attackAvailable = true;
    private bool respawnAvailable = true;
    private bool spawning = false;
    public GameObject bomb;
    private int attackRange;
    private bool attacking = false;

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

    public void StartBomb()
    {
        StartCoroutine(AttackCoolDown());
    }

    private IEnumerator AttackCoolDown()
    {

        yield return new WaitForSeconds(attacktime);
        Debug.Log("Throwing");
        bomb.GetComponent<BombController>().Throw(targetPlayer.transform);
        
        attacking = false;
        yield return new WaitForSeconds(attackCoolDownTime);
        attackAvailable = true;
        respawnAvailable = true;
        //Debug.Log("Attack avaliable");



    }

    private IEnumerator RespawnCoolDown()
    {
        yield return new WaitForSeconds(respawnTime/2.0f);
        particles.EndSpawn();
        yield return new WaitForSeconds(respawnTime/2.0f);
        //attackAvailable = true;
        spawning = false;
        yield return new WaitForSeconds(respawnCoolDownTime);
        particles.EndSpawn();
        respawnAvailable = true;


    }

    private void CheckAttack()
    {
        if (attackAvailable && !spawning && !attacking)
        {
            int rand = Random.Range(0, 200);
            //if(rand == 1)
            {
                Debug.Log("StartAttack");
                animator.SetBool("isAttack", true);
                attackAvailable = false;
                
                GetTarget();
                if (targetPlayer != null)
                {
                    //transform.LookAt(targetPlayer.transform);
                    bomb.SetActive(true);
                    attacking = true;
                    
                }
            }
        }
    }

    private void CheckRespawn()
    {
        if ((Vector3.Distance(this.transform.position, targetPlayer.transform.position) > attackRange) && attackAvailable && respawnAvailable && !spawning)
        {
            Debug.Log("Respawning");
            particles.Spawn();
            //attackAvailable = false;
            respawnAvailable = false;
            spawning = true;
            StartCoroutine(RespawnCoolDown());
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        CheckAttack();
        //CheckRespawn();
    }
}
