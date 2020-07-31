using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomGenerationController : MonoBehaviour
{
    
    public int NumberOfRooms;
    public GameObject closedRoom;
    public GameObject LeftSingle;
    public GameObject[] LeftRooms;
    public GameObject RightSingle;
    public GameObject[] RightRooms;
    public GameObject TopSingle;
    public GameObject[] TopRooms;
    public GameObject BottomSingle;
    public GameObject[] BottomRooms;

    public int spawnOrder = 0;

    public int isLocked = 0;

    public List<GameObject> spawnedRooms = new List<GameObject>();
    public List<SpawnPoint> toSpawn = new List<SpawnPoint>();

    public float waitTime = 0.1f;

    public float startTime = 0;


    private void Update()
    {
        if(toSpawn.Count > 0 && Time.time - startTime > waitTime)
        {
            toSpawn[0].SpawnRoom();
            startTime = Time.time;
        }
        if(toSpawn.Count == 0 && Time.time > waitTime * NumberOfRooms)
        {
            if(spawnedRooms.Count != NumberOfRooms)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                GameObject[] spawns = GameObject.FindGameObjectsWithTag("SpawnPoint");
                foreach(GameObject spawn in spawns)
                {
                    Destroy(spawn);
                }

                GameObject[] destroys = GameObject.FindGameObjectsWithTag("DestroyPoint");
                foreach (GameObject destroy in destroys)
                {
                    Destroy(destroy);
                }
            }
        }
    }
}
