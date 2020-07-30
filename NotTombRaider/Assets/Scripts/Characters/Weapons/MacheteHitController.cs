using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacheteHitController : MonoBehaviour
{
    // Start is called before the first frame update
    public MacheteController macheteController;
    private void OnCollisionEnter(Collision other)
    {
        if (macheteController.isSwinging)
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Hit " + other.gameObject.name);
            }
        }
    }

}
