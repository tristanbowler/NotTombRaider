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
    public GameObject[] enemies;
    public GameObject[] boobyTraps;

    private void Start()
    {
        mainCamera = Camera.main.gameObject;
        controller = GameObject.FindGameObjectWithTag("RoomsController").GetComponent<RoomGenerationController>();
        //Invoke("SpawnAdjacents", 0.01f);
        foreach(GameObject trap in boobyTraps)
        {
            trap.SetActive(false);
        }
        foreach(GameObject enemy in enemies)
        {
            enemy.SetActive(false);
        }
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
            foreach (GameObject trap in boobyTraps)
            {
                trap.SetActive(true);
            }
            foreach (GameObject enemy in enemies)
            {
                enemy.SetActive(true);
            }
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
        if(!playerOneIn && !playerTwoIn)
        {
            foreach (GameObject trap in boobyTraps)
            {
                trap.SetActive(false);
            }
            foreach (GameObject enemy in enemies)
            {
                enemy.SetActive(false);
            }
        }
    }


}
