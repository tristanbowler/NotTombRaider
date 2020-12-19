using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleController : MonoBehaviour
{
    Damage damage;
    public bool isPlayerWeapon;
    // Start is called before the first frame update
    void Start()
    {
        damage = this.GetComponent<Damage>();
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (isPlayerWeapon)
        {
            if (other.gameObject.tag == "Enemy")
            {
                //other.gameObject.SetActive(false)
                other.gameObject.GetComponent<HealthContorller>().DoDamage(damage.damage);
            }
        }

        else
        {
            if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
            {
                other.gameObject.GetComponent<HealthContorller>().DoDamage(damage.damage);
            }
        }
        
    }


}
