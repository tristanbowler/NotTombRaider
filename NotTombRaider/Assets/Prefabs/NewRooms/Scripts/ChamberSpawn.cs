using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamberSpawn : MonoBehaviour
{
    public GameObject room;
    public GameObject deadEnd;
    public GameObject[] chambersList;
    public bool success = false;
    void Start()
    {
    }

    public void Spawn()
    {
        int rand = Random.Range(0, chambersList.Length);
        GameObject chamber = Instantiate(chambersList[rand]);
        //corridor.transform.parent = this.transform;
        chamber.transform.position = this.transform.position;
        chamber.transform.rotation = this.transform.rotation;
        //check for collision
        //if collision delete and try a new one. 
        if (chamber.GetComponent<Chamber>().numRoomCollisions != 0)
        {
            Destroy(chamber);
            for (int i = 0; i < chambersList.Length; i++)
            {
                if (i != rand)
                {
                    chamber = Instantiate(chambersList[i]);
                    //corridor.transform.parent = this.transform;
                    chamber.transform.position = this.transform.position;
                    chamber.transform.rotation = this.transform.rotation;
                    if (chamber.GetComponent<Corridor>().numRoomCollisions != 0)
                    {
                        Destroy(chamber);
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
