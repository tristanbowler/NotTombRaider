using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour
{
    public GameObject Thief;
    public GameObject Fighter;
    public GameObject livesPanel;
    public GameObject livesPrefab;
    public int currentLives;
    public int startLives;
    public int maxLives;


    private void Start()
    {
        Thief = GameObject.FindGameObjectWithTag("Player1");
        Fighter = GameObject.FindGameObjectWithTag("Player2");
        for(int i=0; i<startLives; i++)
        {
            AddLife();
        }
    }

    public void AddLife()
    {
        if(currentLives < maxLives)
        {
            currentLives++;
            Instantiate(livesPrefab, livesPanel.transform);
        }
    }

    public void RemoveLife()
    {
        if (currentLives > 0)
        {
            currentLives--;
            Transform[] lives = livesPanel.GetComponents<Transform>();
            Destroy(lives[lives.Length - 1].gameObject);
        }
    }


}
