using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorSpawn : MonoBehaviour
{
    public GameObject room;
    public GameObject deadEnd;
    public GameObject[] corridorsList;
    public bool success = false;
    void Start()
    {
    }

    public void Spawn()
    {
        int rand = Random.Range(0, corridorsList.Length);
        GameObject corridor = Instantiate(corridorsList[rand]);
        //corridor.transform.parent = this.transform;
        corridor.transform.position = this.transform.position;
        corridor.transform.rotation = this.transform.rotation;
        //check for collision
        //if collision delete and try a new one. 
        if (corridor.GetComponent<Corridor>().numRoomCollisions != 0)
        {
            Destroy(corridor);
            for(int i = 0; i<corridorsList.Length; i++)
            {
                if (i != rand)
                {
                    corridor = Instantiate(corridorsList[i]);
                    //corridor.transform.parent = this.transform;
                    corridor.transform.position = this.transform.position;
                    corridor.transform.rotation = this.transform.rotation;
                    if (corridor.GetComponent<Corridor>().numRoomCollisions != 0)
                    {
                        Destroy(corridor);
                    }
                    else
                    {
                        success = true;
                        break;
                    }
                }
            }
            if (!success)
            {
                deadEnd.SetActive(true);
            }
        }
        else
        {
            success = true;
        }
    }
    
}
