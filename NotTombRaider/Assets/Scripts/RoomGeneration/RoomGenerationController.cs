using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerationController : MonoBehaviour
{
    public GameObject[] LeftRooms;
    public GameObject[] RightRooms;
    public GameObject[] TopRooms;
    public GameObject[] BottomRooms;

    public List<GameObject> spawnedRooms = new List<GameObject>();
}
