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
    public List<GameObject> pillars;


    private void Start()
    {
        roomController = GameObject.FindGameObjectWithTag("RoomsController").GetComponent<RoomGenerationController>();
        detailController = GameObject.FindGameObjectWithTag("RoomsController").GetComponent<RandomDetailPlacementController>();
        if (!this.CompareTag("ClosedRoom"))
        {
            SpawnPots();
            SpawnPillars();
            SpawnEnemies();
        }
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
                child.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    private void SpawnPillars()
    {
        int random = Random.Range(0, detailController.pillarSpots.Length);
        GameObject pillarsArrangement = Instantiate(detailController.pillarSpots[random], this.transform);
        Transform[] children = pillarsArrangement.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.CompareTag(detailController.pillarSpotTag))
            {
                int randomPillar = Random.Range(0, detailController.pillars.Length);
                GameObject pillar = Instantiate(detailController.pillars[randomPillar]);
                pillar.transform.parent = child;
                pillar.transform.position = child.position;
                pillars.Add(pillar);
                child.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    private void SpawnEnemies()
    {
        int random = Random.Range(0, detailController.enemySpots.Length);
        GameObject enemiesArrangement = Instantiate(detailController.enemySpots[random], this.transform);
        Transform[] children = enemiesArrangement.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.CompareTag(detailController.enemySpotTag))
            {
                int randomEnemy = Random.Range(0, detailController.enemies.Length);
                GameObject enemy = Instantiate(detailController.enemies[randomEnemy], child);
                //enemy.transform.parent = child;
                enemy.transform.position = child.position;
                enemies.Add(enemy);
                child.GetComponent<MeshRenderer>().enabled = false;
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
        if(playerOneIn || playerTwoIn)
        {
            foreach (GameObject trap in boobyTraps)
            {
                //trap.SetActive(true);
            }
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<EnemyController>().enabled = true;
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
            
            
        }
    }


}
