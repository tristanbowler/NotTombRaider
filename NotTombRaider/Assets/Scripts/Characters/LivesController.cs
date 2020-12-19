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
    public int PoitionHP;
    public List<GameObject> hearts;

    private void Start()
    {
        Thief = GameObject.FindGameObjectWithTag("Player1");
        Fighter = GameObject.FindGameObjectWithTag("Player2");
        hearts = new List<GameObject>();
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
            GameObject heart = Instantiate(livesPrefab, livesPanel.transform);
            hearts.Add(heart);
        }
    }

    public void RemoveLife()
    {
        if (currentLives > 0)
        {
            currentLives--;
            Destroy(hearts[hearts.Count -1]);
            hearts.Remove(hearts[hearts.Count - 1]);
        }
    }


}
