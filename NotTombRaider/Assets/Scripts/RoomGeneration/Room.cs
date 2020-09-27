using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Animations;
using System.Linq;

public class Room : MonoBehaviour
{
    // Start is called before the first frame update
    public List<SpawnPoint> SpawnPoints;
    private RoomGenerationController roomController;
    private RandomDetailPlacementController detailController;
    public int spawnOrder = -1;
    public TextMeshProUGUI orderLabel;
    public bool playerOneIn = false;
    public bool playerTwoIn = false;
    public List<GameObject> enemies;
    public List<GameObject> boobyTraps;
    public List<GameObject> pots;


    private void Start()
    {
        roomController = GameObject.FindGameObjectWithTag("RoomsController").GetComponent<RoomGenerationController>();
        detailController = GameObject.FindGameObjectWithTag("RoomsController").GetComponent<RandomDetailPlacementController>();
        SpawnPots();
    }

    private void SpawnPots()
    {
        int random = Random.Range(0, detailController.potSpots.Length);
        GameObject potsArrangement = Instantiate(detailController.potSpots[random], this.transform);
        Transform[] children = potsArrangement.GetComponentsInChildren<Transform>();
        foreach(Transform child in children)
        {
            if (child.CompareTag(detailController.potSpotTag))
            {
                int randomPot = Random.Range(0, detailController.pots.Length);
                GameObject pot = Instantiate(detailController.pots[randomPot]);
                pot.transform.parent = child;
                pot.transform.position = child.position;
                pots.Add(pot);
            }
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
