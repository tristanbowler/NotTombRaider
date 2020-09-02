using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipController : MonoBehaviour
{
    public GameObject whipTail;
    public float whipTime;
    public float coolDownTime = 2;
    public float whipRange = 5;
    private Vector3 rangeScale;
    private Vector3 startScale;
    private float whipStart;
    public bool isSnap = false;


    // Start is called before the first frame update
    void Start()
    {
        whipTail.SetActive(false);
        //rangeScale = new Vector3(1, 1, whipRange);
        //startScale = new Vector3(1,1,1);
    }

    // Update is called once per frame
    void Update()
    {
        if(isSnap && Time.time - whipStart >= whipTime)
        {
            RetractWhip();
        }
        if(isSnap && Time.time - whipStart >= coolDownTime){
            isSnap = false;
        }
    }

    public void SnapWhip()
    {
        if(!isSnap)
        {
            whipStart = Time.time;
            isSnap = true;
            this.GetComponent<MeshRenderer>().enabled = false;
            whipTail.SetActive(true);
            //whipTail.transform.localScale = rangeScale;
        }
        

    }

    public void RetractWhip()
    {
        this.GetComponent<MeshRenderer>().enabled = true;
        //whipTail.transform.localScale = startScale;
        whipTail.SetActive(false);
    }
}
