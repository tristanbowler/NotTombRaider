using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public int isLocked = 0;

    public List<GameObject> spawnedRooms = new List<GameObject>();
    public List<SpawnPoint> toSpawn = new List<SpawnPoint>();
}
