using HinputClasses;
using Microsoft.Unity.VisualStudio.Editor;
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
    public float StartWidth;
    public Animator animator;
    public GameObject respawnParticles;
    public GameObject deathParticles;
    
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent<Animator>(out animator);
        HealthPoints = TotalHealth;
        percent = 1;
        Vector2 size = UIBar.GetComponent<RectTransform>().sizeDelta;
        StartWidth = size.x;
    }

    public void DoDamage(int damage)
    {
        Debug.Log(this.gameObject.name + " Taking " + damage + " damage");

        HealthPoints -= damage;
        if(HealthPoints <= 0)
        {
            HealthPoints = 0;
            if (!isPlayer)
            {
                isDead = true;
                animator.SetBool("isWalk", false);
                animator.SetBool("isDeath", true);
                this.gameObject.GetComponent<EnemyParticleController>().Death();
                //this.gameObject.SetActive(false);
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
        percent = (float)HealthPoints / TotalHealth;
        Vector2 size = UIBar.GetComponent<RectTransform>().sizeDelta;
        size.x = StartWidth*percent;
        UIBar.GetComponent<RectTransform>().sizeDelta = size;
    }

    private void AwaitReSpawn()
    {
        isDead = true;
        animator.SetBool("isWalk", false);
        animator.SetBool("isDeath", true);
        deathParticles.SetActive(true);
        respawnParticles.SetActive(false);
    }

    public void Respawn()
    {
        HealthPoints = TotalHealth;
        UpdateUI();
        animator.SetBool("isDeath", false);
        deathParticles.SetActive(false);
        respawnParticles.SetActive(true);
    }
}
