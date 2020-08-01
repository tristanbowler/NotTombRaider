using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacheteController : MonoBehaviour
{
    public Quaternion startRotation;
    public bool isSwinging = false;
    public float swingTime = 1.0f;
    private bool upSwing = false;
    private float startTime;
    public Vector3 previous;
    public float minX = 10;
    public float maxX = 120;
    public float minZ = -20;
    public float maxZ = 20;

    // Start is called before the first frame update
    void Start()
    {
        startRotation = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //move to (50, 0, 0, 0)
        //then to (110, 0, 0, 0)
        
        RotateMachete();
    }


    public void Swing()
    {
        if (!isSwinging)
        {
            isSwinging = true;
            startTime = Time.time;
            upSwing = true;
            previous = startRotation.eulerAngles;
        }
    }

    private void RotateMachete()
    {
        if (isSwinging)
        {
            if (upSwing)
            {
                Vector3 rotation = this.transform.localRotation.eulerAngles;
                float deltaX = (maxX - minX) / (3* swingTime / 4) * Time.deltaTime;
                float deltaZ = (maxZ - minZ) / (3*swingTime / 4) * Time.deltaTime;
                rotation = new Vector3(previous.x - deltaX, 0, 0);
                previous = rotation;
                this.transform.localRotation = Quaternion.Euler(rotation);
                if (rotation.x <= minX)
                {
                    upSwing = false;
                }
            }
            else
            {
                Vector3 rotation = this.transform.localRotation.eulerAngles;
                float deltaX = (maxX - minX) / (swingTime / 4) * Time.deltaTime;
                float deltaZ = (maxZ - minZ) / (swingTime / 4) * Time.deltaTime;
                rotation = new Vector3(previous.x + deltaX, 0, 0);
                previous = rotation;

                this.transform.localRotation = Quaternion.Euler(rotation);
                if (rotation.x >= maxX)
                {
                    isSwinging = false;
                    this.transform.localRotation = startRotation;
                }
            }
        }
    }


    
}
