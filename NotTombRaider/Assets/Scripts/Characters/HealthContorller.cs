using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HealthContorller : MonoBehaviour
{
    [Header("Player Character Stuff")]
    public bool isPlayer = false;
    public GameObject liveModel;
    public GameObject deadModel;
    public LivesController livesController;
    [Header("All Characters")]
    public bool isDead = false;
    public int TotalHealth = 100;
    public int HealthPoints = 100;
    public float percent;
    public GameObject UIBar;
    
    // Start is called before the first frame update
    void Start()
    {
        HealthPoints = TotalHealth;
        percent = 1;
    }

    public void DoDamage(int damage)
    {
        HealthPoints -= damage;
        if(HealthPoints <= 0)
        {
            HealthPoints = 0;
            if (!isPlayer)
            {
                isDead = true;
                this.gameObject.SetActive(false);
            }
            else
            {
                AwaitReSpawn();
            }
        }
        UpdateUI();
    }

    public void Heal(int health)
    {
        HealthPoints += health;
        if(HealthPoints > TotalHealth)
        {
            HealthPoints = TotalHealth;
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        percent = HealthPoints / TotalHealth;
        Vector3 scale = UIBar.transform.localScale;
        scale.x = percent;
        UIBar.transform.localScale = scale;
    }

    private void AwaitReSpawn()
    {
        isDead = true;

    }
}
