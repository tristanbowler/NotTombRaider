using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenController : MonoBehaviour
{
    public Transform[] spawnPoints;
    private GameObject targetPlayer;
    private Vector3 targetPosition;
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


    private GameObject GetTarget(bool near)
    {
        GameObject target;

        if (near)
        {
            if (Vector3.Distance(this.transform.position, player1.gameObject.transform.position) <= Vector3.Distance(this.transform.position, player2.gameObject.transform.position))
            {
                if (!player1.isDead)
                {
                    target = player1.gameObject;
                }
                else if (!player2.isDead)
                {
                    target = player2.gameObject;
                }
                else
                {
                    target= null;
                }
            }
            else
            {
                if (!player2.isDead)
                {
                    target = player2.gameObject;
                }
                else if (!player1.isDead)
                {
                    target = player1.gameObject;
                }
                else
                {
                    target = null;
                }
            }
        }
        else
        {
            if (Vector3.Distance(this.transform.position, player1.gameObject.transform.position) < Vector3.Distance(this.transform.position, player2.gameObject.transform.position))
            {
                if (!player2.isDead)
                {
                    target = player2.gameObject;
                }
                else if (!player1.isDead)
                {
                    target = player1.gameObject;
                }
                else
                {
                    target = null;
                }
            }
            else
            {
                if (!player1.isDead)
                {
                    target = player1.gameObject;
                }
                else if (!player2.isDead)
                {
                    target = player2.gameObject;
                }
                else
                {
                    target = null;
                }
            }
        }
        return target;
    }

    private void GetLocation()
    {
        GameObject target = GetTarget(false);
        Vector3 closestPoisition = Vector3.zero;
        float distance = float.MaxValue;
        foreach(Transform p in spawnPoints)
        {
            float temp = Vector3.Distance(target.transform.position, p.position);
            if(temp < distance && Vector3.Distance(this.transform.position, p.position) > 2)
            {
                distance = temp;
                closestPoisition = p.position;
            }
        }

        targetPosition = closestPoisition;
    }

    public void StartBomb()
    {
        StartCoroutine(AttackCoolDown());
    }

    private IEnumerator AttackCoolDown()
    {

        yield return new WaitForSeconds(attacktime);
        Debug.Log("Throwing");
        //targetPlayer = GetTarget(true);
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
        GetLocation();
        this.transform.position = targetPosition;
        this.transform.LookAt(targetPlayer.transform);
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
                this.transform.LookAt(targetPlayer.transform);
                //targetPlayer = GetTarget(true);
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
        targetPlayer = GetTarget(true);
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
        targetPlayer = GetTarget(true);
        CheckRespawn();
        CheckAttack();
        
    }
}
