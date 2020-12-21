using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskController : MonoBehaviour
{
    public GameObject icon;
    public GameObject Exit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
            if (Input.GetKeyDown(KeyCode.X) || other.GetComponent<ThiefController>().controller.CheckA())
            {
                icon.SetActive(true);
                Exit.SetActive(true);
                Camera.main.gameObject.GetComponent<LivesController>().relicFound = true;
                this.gameObject.SetActive(false);
            }
        }

        else if (other.gameObject.CompareTag("Player2"))
        {
            if (Input.GetKeyDown(KeyCode.Alpha3) || other.GetComponent<FighterController>().controller.CheckA())
            {
                icon.SetActive(true);
                Exit.SetActive(true);
                Camera.main.gameObject.GetComponent<LivesController>().relicFound = true;
                this.gameObject.SetActive(false);
            }
        }
    }
}
