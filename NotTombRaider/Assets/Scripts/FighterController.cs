using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 1;
    public GunController gun;
    public MacheteController machete;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement();
        CheckGun();
        CheckMachete();
    }

    private void CheckMachete()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            machete.Swing();
        }
    }

    private void CheckGun()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            gun.FireBullet();
        }
    }
    private void CheckMovement()
    {
        Vector3 movement = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Move forward: Increase Z
            movement += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Move back: Decrease Z
            movement += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Move left: Increase X
            movement += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Move right: Decrease X
            movement += new Vector3(1, 0, 0);
        }

        movement = movement.normalized;
        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}
