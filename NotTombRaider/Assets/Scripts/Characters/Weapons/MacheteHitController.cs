using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacheteHitController : MonoBehaviour
{
    public bool isPlayerWeapon = true;
    // Start is called before the first frame update
    public MacheteController macheteController;
    private void OnCollisionEnter(Collision other)
    {
        if (macheteController.isSwinging)
        {
            if (isPlayerWeapon)
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
            else
            {
                if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
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

}
