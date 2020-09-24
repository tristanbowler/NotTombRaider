using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    // Start is called before the first frame update
   public void FireDart(float force)
    {
        this.GetComponent<Rigidbody>().AddForce(this.transform.forward.normalized * force);
        this.GetComponent<Rigidbody>().useGravity = true;
        Debug.Log("Fired dart");
    }

    private void OnCollisionEnter(Collision other)
    {
        
        Debug.Log("Hit " + other.gameObject.name);
        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            
        }
    }
}
