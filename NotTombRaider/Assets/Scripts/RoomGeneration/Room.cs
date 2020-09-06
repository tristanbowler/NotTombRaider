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
    public bool playerOneIn = false;
    public bool playerTwoIn = false;
    private GameObject[] enemies;
    private GameObject[] boobyTraps;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("RoomsController").GetComponent<RoomGenerationController>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        boobyTraps = GameObject.FindGameObjectsWithTag("Trap");
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
