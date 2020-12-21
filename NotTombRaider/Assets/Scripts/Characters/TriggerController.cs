using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            if (other.GetComponent<SkeleController>())
            {
                other.GetComponent<SkeleController>().enabled = true;
                other.GetComponent<HideAndShow>().Show();
            }
            if (other.GetComponent<SoldierController>())
            {
                other.GetComponent<SoldierController>().enabled = true;
            }
            
        }
    }
}
