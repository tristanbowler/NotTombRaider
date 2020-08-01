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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement();
        CheckWhip();
    }

    private void CheckWhip()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            whip.SnapWhip();
        }
    }

    private void CheckMovement()
    {
        movement = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            //Move forward: Increase Z
            movement += new Vector3(0, 0, 1);
            moving = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //Move back: Decrease Z
            movement += new Vector3(0, 0, -1);
            moving = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //Move left: Increase X
            movement += new Vector3(-1, 0, 0);
            moving = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //Move right: Decrease X
            movement += new Vector3(1, 0, 0);
            moving = true;
        }
        if (moving)
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
}
