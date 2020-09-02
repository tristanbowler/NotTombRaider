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
    private GameObject otherObj = null;

    private void Start()
    {
        startPos = transform.position;
        endPos = startPos + offset;
    }
    private void OnTriggerEnter(Collider other)
    {
        if((other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2")) && !isTriggered)
        {
            otherObj = other.gameObject;
            Debug.Log(otherObj.name);
            isTriggered = true;
            isReleased = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        /*if ((other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2")) && ! isReleased)
        {
            otherObj = null;
            trap.Released();
            isReleased = true;
            isTriggered = false;
        }*/
    }

   

    private void Update()
    {
        if (isTriggered && otherObj != null)
        {
            if (Vector3.Distance(this.transform.position, otherObj.transform.position) < this.transform.localScale.x/ 2)
            {
                trap.Triggered();
                isReleased = false;
            }
            else if (Vector3.Distance(this.transform.position, otherObj.transform.position) > this.transform.localScale.x*0.9f)
            {
                otherObj = null;
                trap.Released();
                isReleased = true;
                isTriggered = false;
            }

           
        }
    }
}
