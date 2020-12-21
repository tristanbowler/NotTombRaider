using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitController : MonoBehaviour
{
    public GameObject winScreen;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))
        {
            if (Camera.main.GetComponent<LivesController>().relicFound)
            {
                Camera.main.GetComponent<LivesController>().winScreen.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }
}
