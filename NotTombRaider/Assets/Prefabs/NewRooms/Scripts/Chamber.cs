using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chamber : MonoBehaviour
{
    public int numRoomCollisions = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Room") || other.gameObject.CompareTag("Hallway"))
        {
            numRoomCollisions++;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Room") || other.gameObject.CompareTag("Hallway"))
        {
            numRoomCollisions--;
        }
    }

}
