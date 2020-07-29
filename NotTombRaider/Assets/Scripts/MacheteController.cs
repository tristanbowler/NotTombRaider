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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Swing();
        }
        if (isSwinging)
        {
            if (upSwing)
            {
                Vector3 rotation = this.transform.rotation.eulerAngles;
                float deltaX = 60 / (swingTime / 2) * Time.deltaTime;
                rotation = new Vector3(previous.x - deltaX, 0, 0);
                previous = rotation;
                this.transform.rotation = Quaternion.Euler(rotation);
                if(rotation.x <= 50)
                {
                    upSwing = false;
                }
            }
            else
            {
                Vector3 rotation = this.transform.rotation.eulerAngles;
                Debug.Log("Down: " + rotation);
                float deltaX = 60 / (swingTime / 2) * Time.deltaTime;
                Debug.Log("Delta: " + deltaX);
                rotation = new Vector3(previous.x + deltaX, 0, 0);
                previous = rotation;
                
                this.transform.rotation = Quaternion.Euler(rotation);
                if(rotation.x >= 110)
                {
                    isSwinging = false;
                    this.transform.rotation = startRotation;
                }
            }
        }
    }

    public void Swing()
    {
        if (!isSwinging)
        {
            isSwinging = true;
            startTime = Time.time;
            upSwing = true;
            previous = startRotation.eulerAngles;
            //StartCoroutine(SwingWait());
        }
    }

    private IEnumerator SwingWait()
    {
        yield return new WaitForSeconds(swingTime + 0.1f);
        
        
    }
}
