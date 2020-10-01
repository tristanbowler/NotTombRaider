using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public bool enviroCollision;
    private void OnCollisionEnter(Collision collision)
    {
        //11 is Envionment
        if(collision.collider.gameObject.layer == 11)
        {
            enviroCollision = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        //11 is Envionment
        if (collision.collider.gameObject.layer == 11)
        {
            enviroCollision = false;
        }
    }
}
