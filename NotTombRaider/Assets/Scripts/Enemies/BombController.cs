using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public GameObject parentObject;
    public Vector3 startPosition;
    public Damage damage;
    public float force;
    public bool thrown;
    public float endSize;

    private void Awake()
    {
        //parent = this.parent.transform.gameObject;
        //startPosition = this.transform.localPosition;
        //damage = this.GetComponent<Damage>();
    }

    public void Throw(Transform target)
    {
        //this.transform.LookAt(target);
        Debug.Log("Target "+target.position);
        this.transform.parent = null;
        Debug.Log("Parent " + this.transform.parent);
        Vector3 difference = target.position - this.transform.position;
        //difference = difference.normalized;
        this.GetComponent<Rigidbody>().AddForce(difference * force);
        thrown = true;
        StartCoroutine(RecallBomb());
    }

    IEnumerator RecallBomb()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Recalling");
        Reload();
    }

    public void Reload()
    {
        Debug.Log("Reloading");
        this.transform.parent = parentObject.transform;
        Debug.Log("Parent " + this.transform.parent);
        this.transform.localPosition = startPosition;
        this.transform.localRotation = Quaternion.Euler(Vector3.zero);
        thrown = false;

        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!thrown)
        {
            this.transform.localPosition = startPosition;
        }
        else
        {
            //float increment = endSize / speed;
            //this.transform.localScale = this.transform.localScale + new Vector3(1, 1, 1) * increment;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            collision.gameObject.GetComponent<HealthContorller>().DoDamage(damage.damage);
            Reload();
        }
        

    }

    
}
