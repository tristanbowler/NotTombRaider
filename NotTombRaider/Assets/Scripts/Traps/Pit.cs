using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pit : MonoBehaviour
{ 

    public bool isTop = true;


    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.layer == 8 || other.gameObject.layer == 9)
        {
            Debug.Log("Player entered pit");
            //players
            if (other.GetComponent<Rigidbody>())
            {
                if (isTop)
                {

                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                }
                else
                {
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
                }
            }
        }
        else
        {
            Debug.Log("Entered: " + other.gameObject.name + " Layer: " + other.gameObject.layer);
        }
    }
}
