using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefController : MonoBehaviour
{
    public float moveSpeed = 1;
    public bool moving = false;
    private Quaternion targetRotation;
    private Vector3 movement;
    public float degreesPerSecond = 180;
    public WhipController whip;
    public GamepadController controller;
    public bool collisionDetected;
    private Rigidbody rigidBody;
    public float collisionForce = 100;
    public bool controllsConnected = false;
    public Animator animator;
    public HealthContorller healthController;
    public bool isTorch;
    public bool isMele;
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
        animator = this.gameObject.GetComponent<Animator>();
        healthController = this.GetComponent<HealthContorller>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement();
        CheckMele();
        CheckTorch();
        CheckReSpawn();
    }

    IEnumerator WaitForAttack(int waitTime, bool isTorch)
    {

        yield return new WaitForSeconds(waitTime);
        if (isTorch)
        {
            isTorch = false;
        }
        else
        {
            isMele = false;
        }
    }

    private void CheckReSpawn()
    {
        if (Input.GetKeyDown(KeyCode.Y) && healthController.isDead)
        {
            healthController.Respawn();
        }
    }

    private void CheckMele()
    {
        if(Input.GetKey(KeyCode.E) && !healthController.isDead)
        {
            //whip.SnapWhip();
            animator.SetBool("isMele", true);
        }
    }

    private void CheckTorch()
    {
        if (Input.GetKey(KeyCode.Q) && !healthController.isDead)
        {
            //whip.SnapWhip();
            animator.SetBool("isTorch", true);
        }
    }

    private void CheckMovement()
    {
        movement = new Vector3(0, 0, 0);
        if (!healthController.isDead)
        {


            

            if (controllsConnected && controller != null && (!controller.stickHorizontal.Equals(0) || !controller.stickVertical.Equals(0)))
            {
                moving = true;
                movement += controller.stickHorizontal * (new Vector3(1, 0, 0));
                movement += controller.stickVertical * (new Vector3(0, 0, 1));
            }
            else
            {
                if (Input.GetKey(KeyCode.W))
                {
                    //Move forward: Increase Z
                    movement += new Vector3(0, 0, moveSpeed);
                    moving = true;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    //Move back: Decrease Z
                    movement += new Vector3(0, 0, -1 * moveSpeed);
                    moving = true;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    //Move left: Increase X
                    movement += new Vector3(-1 * moveSpeed, 0, 0);
                    moving = true;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    //Move right: Decrease X
                    movement += new Vector3(moveSpeed, 0, 0);
                    moving = true;
                }
            }
            if (moving && !collisionDetected)
            {
                movement = movement.normalized;
                transform.position += movement * moveSpeed * Time.deltaTime;
                Vector3 xzDirection = new Vector3(movement.x, 0, movement.z);
                if (xzDirection.magnitude > 0)
                {
                    targetRotation = Quaternion.LookRotation(xzDirection);
                }

                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, degreesPerSecond * Time.deltaTime);
                moving = false;
            }
        }

        if (movement == Vector3.zero)
        {
            animator.SetBool("isWalk", false);
        }
        else if (!isTorch && !isMele)
        {
            animator.SetBool("isWalk", true);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyWeapon"))
        {
            //int damage = collision.gameObject.GetComponent<Damage>().damage;
        }
        else
        {
            Debug.Log("Collision with " + collision.gameObject.name);
            //collisionDetected = true;
            //Vector3 direction = transform.position - collision.collider.transform.position;
            //direction.Normalize();
            //rigidBody.AddForce(direction * collisionForce);
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        //collisionDetected = false;
        //rigidBody.velocity = Vector3.Lerp(rigidBody.velocity, Vector3.zero, 0.90f);
        //rigidBody.velocity = Vector3.zero;
        //rigidBody.angularVelocity = Vector3.zero;
    }
    


}
