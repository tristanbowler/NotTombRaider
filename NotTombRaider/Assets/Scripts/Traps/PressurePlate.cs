using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    public Trap trap;
    private Vector3 startPos;
    public Vector3 offset;
    private Vector3 endPos;
    public bool isTriggered = false;
    public bool isReleased = false;
    public float moveSpeed = 1;

    private void Start()
    {
        startPos = transform.position;
        endPos = startPos + offset;
    }
    private void OnTriggerEnter(Collider other)
    {
        if((other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2")) && !isTriggered)
        {
            trap.Triggered();
            isTriggered = true;
            isReleased = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2")) && ! isReleased)
        {
            trap.Released();
            isReleased = true;
            isTriggered = false;
        }
    }

   

    private void Update()
    {
       
    }
}
