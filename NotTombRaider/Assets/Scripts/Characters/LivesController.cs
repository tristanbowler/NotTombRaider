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
    public int HeartIndex = 0;
    public GameObject gameOverScreen;
    public bool relicFound = false;
    public GameObject winScreen;

    private void Start()
    {
        Brain = GameObject.FindGameObjectWithTag("Player1").GetComponent<HealthContorller>();
        Brawn = GameObject.FindGameObjectWithTag("Player2").GetComponent<HealthContorller>();

        //for(int i=0; i<startLives; i++)
        //{
        //    AddLife();
        //}
        hearts[HeartIndex].SetActive(true);
        gameOverScreen.SetActive(false);
        currentLives = 5;
    }

    public void AddLife()
    {
        if (currentLives < maxLives)
        {
            currentLives++;
            //GameObject heart = Instantiate(livesPrefab, livesPanel.transform);
            //hearts.Add(heart);

            hearts[HeartIndex].SetActive(false);

            HeartIndex--;
            hearts[HeartIndex].SetActive(true);
        }
    }

    public void RemoveLife()
    {
        if (currentLives > 0)
        {
            Debug.Log("RemoveLife");
            currentLives--;
            hearts[HeartIndex].SetActive(false);
            HeartIndex++;
            hearts[HeartIndex].SetActive(true);
        }
    }

    private void Update()
    {
        if (Brain.isDead && Brawn.isDead && currentLives == 0)
        {
            gameOverScreen.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }


}
