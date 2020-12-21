using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionController : MonoBehaviour
{
    public LivesController livesController;
    public int HealthPoints;
    

    // Start is called before the first frame update
    void Start()
    {
        livesController = Camera.main.GetComponent<LivesController>();
        HealthPoints = livesController.PoitionHP;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player1") )
        {
            HealthContorller hc = other.GetComponent<HealthContorller>();
            if ((Input.GetKeyDown(KeyCode.X) || other.GetComponent<ThiefController>().controller.CheckA())&& hc.HealthPoints < hc.TotalHealth)
            {
                other.gameObject.GetComponent<HealthContorller>().Heal(HealthPoints);
                this.gameObject.SetActive(false);
            }
        }
        else if (other.gameObject.CompareTag("Player2"))
        {
            HealthContorller hc = other.GetComponent<HealthContorller>();
            if ((Input.GetKeyDown(KeyCode.Alpha3) || other.GetComponent<FighterController>().controller.CheckA()) && hc.HealthPoints < hc.TotalHealth)
            {
                other.gameObject.GetComponent<HealthContorller>().Heal(HealthPoints);
                this.gameObject.SetActive(false);
            }
        }
    }
}
