using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadWire : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 13)
        {
            //PlayerWeapons
            Debug.Log("Hit by weapon");
            this.gameObject.SetActive(false);
            

        }
        if(other.gameObject.layer == 8 || other.gameObject.layer == 9)
        {
            //Players
            Debug.Log("Hit player");
            other.gameObject.SetActive(false);
        }
    }
}
