using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : Trap 
{
    private Vector3 startPos;
    public Vector3 offset;
    private Vector3 endPos;
    public bool isTriggered;
    public bool isReleased;
    public float moveSpeedUp= 1;
    public float moveSpeedDown = 0.25f;

    private void Start()
    {
        startPos = transform.position;
        endPos = startPos + offset;
    }

    public override void Triggered()
    {
        isTriggered = true;
    }

    public override void Released()
    {
        isReleased = true;
    }

    private void Update()
    {
        if (isTriggered)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, moveSpeedUp * Time.deltaTime);
            if(transform.position == endPos)
            {
                isTriggered = false;
            }
        }
        else if (isReleased)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, moveSpeedDown * Time.deltaTime);
            if(transform.position == startPos)
            {
                isReleased = false;
            }
        }
    }

}
