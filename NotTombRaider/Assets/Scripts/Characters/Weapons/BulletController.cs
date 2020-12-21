using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 startPosition;
    public Quaternion startRotation;
    public GameObject parentObject;
    public GunController gun;
    public Damage damage;

    public Vector3 dest;
    // Start is called before the first frame update


    /*public void Line()
    {
        LineRenderer lr = GetComponent<LineRenderer>();
        lr.enabled = true;
        Debug.Log("Start " + startPosition);
        Debug.Log("Dest " + this.transform.position);
        lr.SetPosition(0, gun.transform.position);
        lr.SetPosition(1, this.transform.position);
       // StartCoroutine(Die());

    }*/

   

    private void Update()
    {
        //Line();

    }


    void Start()
    {
        this.damage = this.gameObject.GetComponent<Damage>();
    }

    

    private void OnCollisionEnter(Collision other)
    {
        LineRenderer lr = GetComponent<LineRenderer>();
        lr.enabled = false;

        if (gun.isPlayerWeapon)
        {
            if (other.gameObject.tag == "Enemy")
            {
                //other.gameObject.SetActive(false)
                other.gameObject.GetComponent<HealthContorller>().DoDamage(damage.damage);

            }
        }
        
        else
        {
            if(other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
            {
                other.gameObject.GetComponent<HealthContorller>().DoDamage(damage.damage);
            }
        }
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Debug.Log("Gun " + gun.gameObject.transform.position);
        transform.parent = parentObject.transform;
        transform.localPosition = startPosition;
        transform.localRotation = startRotation;
        Debug.Log("Here: " + transform.position);
        gun.Reload(this.gameObject);
    }
}
 