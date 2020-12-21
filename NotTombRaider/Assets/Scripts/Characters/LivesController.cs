using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesController : MonoBehaviour
{
    public HealthContorller Brain;
    public HealthContorller Brawn;
    public GameObject livesPanel;
    public GameObject livesPrefab;
    public int currentLives;
    public int startLives;
    public int maxLives;
    public int PoitionHP;
    public List<GameObject> hearts;
    public int maxPotions = 10;
    public int HeartIndex = -1;
    public GameObject gameOverScreen;

    private void Start()
    {
        Brain = GameObject.FindGameObjectWithTag("Player1").GetComponent<HealthContorller>();
        Brawn = GameObject.FindGameObjectWithTag("Player2").GetComponent<HealthContorller>();
        hearts = new List<GameObject>();
        for(int i=0; i<startLives; i++)
        {
            AddLife();
        }
        gameOverScreen.SetActive(false);
    }

    public void AddLife()
    {
        if(currentLives < maxLives)
        {
            currentLives++;
            //GameObject heart = Instantiate(livesPrefab, livesPanel.transform);
            //hearts.Add(heart);
            if(HeartIndex >= 0)
            {
                hearts[HeartIndex].SetActive(false);
            }
            HeartIndex++;
            hearts[HeartIndex].SetActive(true);
            
        }
    }

    public void RemoveLife()
    {
        if (currentLives > 0)
        {
            currentLives--;
            Destroy(hearts[hearts.Count -1]);
            hearts.Remove(hearts[hearts.Count - 1]);
            hearts[HeartIndex].SetActive(false);
            HeartIndex--;
            hearts[HeartIndex].SetActive(true);
        }
    }

    private void Update()
    {
        if(Brain.isDead && Brawn.isDead && currentLives == 0)
        {
            gameOverScreen.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }


}
