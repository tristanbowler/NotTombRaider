using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int health;

    public void DealDammage(int dammage)
    {
        health -= dammage;
    }

    public void Heal(int hp)
    {
        health += hp;
    }

    private void Update()
    {
        if(health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

}
