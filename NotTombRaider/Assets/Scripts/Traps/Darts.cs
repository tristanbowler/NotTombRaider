using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darts : Trap
{
    public bool isTriggered;
    public bool isReleased;
    public bool isFired;
    public float dartForce = 10f;
    public Dart[] darts;


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
        if(isTriggered && !isFired)
        {
            isFired = true;
            foreach (Dart dart in darts)
            {
                dart.FireDart(dartForce);
            }
        }

        
    }

}
