using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLifeController : MonoBehaviour
{
    public LivesController livesController;

    
    // Start is called before the first frame update
    void Start()
    {
        livesController = Camera.main.GetComponent<LivesController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player1") )
        {
            if ((Input.GetKeyDown(KeyCode.X) || other.GetComponent<ThiefController>().controller.CheckA())&& livesController.currentLives < livesController.maxLives)
            {
                livesController.AddLife();
                this.gameObject.SetActive(false);
            }
        }
        else if (other.gameObject.CompareTag("Player2"))
        {
            if ((Input.GetKeyDown(KeyCode.Alpha3) || other.GetComponent<FighterController>().controller.CheckA()) && livesController.currentLives < livesController.maxLives)
            {
                livesController.AddLife();
                this.gameObject.SetActive(false);
            }
        }
    }
}
