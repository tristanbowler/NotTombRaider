using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRoom : MonoBehaviour
{
    public NewRoom ParentRoom;

    public Transform[] spawnPoints;
    public GameObject[] PossibleChildren;
    
    void Start()
    {
        foreach(Transform point in spawnPoints)
        {
            int rand = Random.Range(0, PossibleChildren.Length);

        }
        

    }

    
}
