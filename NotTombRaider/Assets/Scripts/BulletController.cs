using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 startPosition;
    private GunController gun;

    void Start()
    {
        gun = transform.parent.gameObject.GetComponent<GunController>();
        startPosition = this.transform.position;
    }

    

    private void OnCollisionEnter(Collision other)
    {
        gun.Reload(this.gameObject);
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Hit " + other.gameObject.name);
        }
    }
}
