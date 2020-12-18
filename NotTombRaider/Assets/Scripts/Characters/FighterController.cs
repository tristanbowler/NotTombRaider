using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class FighterController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 1;
    public GunController gun;
    public MacheteController machete;
    private Quaternion targetRotation;
    public float degreesPerSecond = 180;
    public bool moving = false;
    public GamepadController controller;
    public bool collisionDetected;
    private Rigidbody rigidBody;
    public float collisionForce = 100;
    public bool controllsConnected = false;
    public Animator animator;
    public bool shooting;
    public bool slashing;
    public HealthContorller healthController;
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement();
        CheckGun();
        CheckMachete();
        CheckReSpawn();
    }

    private void CheckReSpawn()
    {
        if(Input.GetKeyDown(KeyCode.Y) && healthController.isDead)
        {
            healthController.Respawn();
        }
    }
    IEnumerator WaitForAttack(float waitTime, bool isGun)
    {

        yield return new WaitForSeconds(waitTime);
        if (isGun)
        {
            shooting = false;
        }
        else
        {
            slashing = false;
        }
    }

    IEnumerator WaitForAim(float waitTime)
    {
        gun.fireParticles.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        gun.FireBullet();
    }
    private void CheckMachete()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !slashing && !shooting)
        {
            slashing = true;
            animator.SetBool("isAttack", true);
            animator.SetBool("isWalk", false);
            StartCoroutine(WaitForAttack(3, false));
        }
    }

    private void CheckGun()
    {
        if (Input.GetKey(KeyCode.Space) && !slashing && !shooting)
        {
            shooting = true;
            animator.SetBool("isShoot", true);
            animator.SetBool("isWalk", false);
            
            StartCoroutine(WaitForAim(1.1f));
            StartCoroutine(WaitForAttack(2, true));
        }
    }
    private void CheckMovement()
    {
        Vector3 movement = new Vector3(0, 0, 0);
        if(rigidBody.velocity!=Vector3.zero && !collisionDetected)
        {
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
        }
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
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    //Move forward: Increase Z
                    movement += new Vector3(0, 0, moveSpeed);
                    moving = true;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    //Move back: Decrease Z
                    movement += new Vector3(0, 0, -1 * moveSpeed);
                    moving = true;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    //Move left: Increase X
                    movement += new Vector3(-1 * moveSpeed, 0, 0);
                    moving = true;
                }
                if (Input.GetKey(KeyCode.RightArrow))
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
        
        if(movement == Vector3.zero)
        {
            animator.SetBool("isWalk", false);
        }
        else if(!shooting && !slashing)
        {
            animator.SetBool("isWalk", true);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //collisionDetected = true;
        //Vector3 direction = transform.position - collision.collider.transform.position;
        //direction.Normalize();
        //rigidBody.AddForce(direction * collisionForce);
    }

    private void OnCollisionExit(Collision collision)
    {
        //collisionDetected = false;
        //rigidBody.velocity = Vector3.Lerp(rigidBody.velocity, Vector3.zero, 0.90f);
        //rigidBody.velocity = Vector3.zero;
        //rigidBody.angularVelocity = Vector3.zero;
    }
}
