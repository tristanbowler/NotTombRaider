using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDetailPlacementController : MonoBehaviour
{
    [Header("Arrangements")]
    public GameObject[] potSpots;
    public GameObject[] pillarSpots;
    public GameObject[] trapSpots;
    public GameObject[] enemySpots;

    [Header("Prefabs")]
    public GameObject[] pots;
    public GameObject[] pillars;
    public GameObject[] traps;
    public GameObject[] enemies;


    [Header("Tags")]
    public string potSpotTag = "PotSpot";
    public string pillarSpotTag = "PillarSpot";
    public string enemySpotTag = "EnemySpot";
    public string trapSpot = "TrapSpot";

}
