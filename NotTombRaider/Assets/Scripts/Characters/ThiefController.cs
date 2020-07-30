using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefController : MonoBehaviour
{
    public float moveSpeed = 1;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector3 movement = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            //Move forward: Increase Z
            movement += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //Move back: Decrease Z
            movement += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //Move left: Increase X
            movement += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //Move right: Decrease X
            movement += new Vector3(1, 0, 0);
        }
        movement = movement.normalized;
        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}
