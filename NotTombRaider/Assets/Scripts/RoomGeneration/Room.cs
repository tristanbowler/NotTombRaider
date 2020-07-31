using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Room : MonoBehaviour
{
    // Start is called before the first frame update
    public List<SpawnPoint> SpawnPoints;
    private RoomGenerationController controller;
    public int spawnOrder = -1;
    public TextMeshProUGUI orderLabel;
    public GameObject mainCamera;
    public bool playerOneIn = false;
    public bool playerTwoIn = false;

    private void Start()
    {
        mainCamera = Camera.main.gameObject;
        controller = GameObject.FindGameObjectWithTag("RoomsController").GetComponent<RoomGenerationController>();
        //Invoke("SpawnAdjacents", 0.01f);
    }

    public void SetSpawnOrder(int order)
    {
        spawnOrder = order;
        orderLabel.text = spawnOrder.ToString();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            playerOneIn = true;
        }
        if (other.CompareTag("Player2"))
        {
            playerTwoIn = true;
        }
        if(playerOneIn && playerTwoIn)
        {
            mainCamera.transform.position = new Vector3(this.transform.position.x, mainCamera.transform.position.y, this.transform.position.z);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            playerOneIn = false;
        }
        if (other.CompareTag("Player2"))
        {
            playerTwoIn = false;
        }
    }


}
