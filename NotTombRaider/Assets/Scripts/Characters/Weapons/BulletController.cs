using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 startPosition;
    public Quaternion startRotation;
    public GunController gun;

    public Vector3 dest;
    // Start is called before the first frame update


    public void Line()
    {
        LineRenderer lr = GetComponent<LineRenderer>();
        lr.enabled = true;
        Debug.Log("Start " + startPosition);
        Debug.Log("Dest " + this.transform.position);
        lr.SetPosition(0, gun.transform.position);
        lr.SetPosition(1, this.transform.position);
       // StartCoroutine(Die());

    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(2);
        
    }

    private void Update()
    {
        Line();
    }


    void Start()
    {
       
    }

    

    private void OnCollisionEnter(Collision other)
    {
        LineRenderer lr = GetComponent<LineRenderer>();
        lr.enabled = false;

        
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Hit " + other.gameObject.name);
        }
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Debug.Log("Gun " + gun.gameObject.transform.position);
        this.transform.position = gun.gameObject.transform.position;
        Debug.Log("Here: " + transform.position);
        gun.Reload(this.gameObject);
    }
}
 