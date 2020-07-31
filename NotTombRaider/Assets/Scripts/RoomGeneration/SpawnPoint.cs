using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public enum SpawnPointDirection
    {
        Left,
        Right,
        Top,
        Bottom
    };

    public SpawnPointDirection spawnPointDirection;
    private RoomGenerationController controller;
    public bool spawned = false;
    public float creationTime;
    private void Start()
    {
        creationTime = Time.time;
        controller = GameObject.FindGameObjectWithTag("RoomsController").GetComponent<RoomGenerationController>();
        Invoke("DelayedStart", 1f);

    }

    private void DelayedStart()
    {
        lock (controller.spawnedRooms)
        {

            //if ((controller.spawnedRooms.Count + controller.toSpawn.Count) < controller.NumberOfRooms)
            {
                controller.toSpawn.Add(this);
                Invoke("SpawnRoom", 5f);
            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (!spawned && !other.gameObject.GetComponent<SpawnPoint>().spawned)
            {
                GameObject room = Instantiate(controller.closedRoom, transform.position, Quaternion.identity);
                Debug.Log("Overlapping Spawn Points. Spawn Empty and destroy.");
            }
            lock (controller.spawnedRooms)
            {
                if (controller.toSpawn.Contains(this))
                {
                    controller.toSpawn.Remove(this);
                }
            }
            spawned = true;
            Destroy(gameObject);



        }
        if (other.CompareTag("DestroyPoint"))
        {
            Debug.Log("Hit DestroyPoint");

            lock (controller.spawnedRooms)
            {
                if (controller.toSpawn.Contains(this))
                {
                    controller.toSpawn.Remove(this);
                }
            }
            Destroy(gameObject);
        }
    }

    private void SpawnRoom()
    {
        if (!spawned)
        {
            lock (controller.spawnedRooms)
            {
                if (spawnPointDirection == SpawnPoint.SpawnPointDirection.Left)
                {
                    if (controller.spawnedRooms.Count + controller.toSpawn.Count == controller.NumberOfRooms)
                    {
                        Debug.Log("Spawn a rightSingle");
                        GameObject room = Instantiate(controller.RightSingle, transform.position, Quaternion.identity);
                        controller.spawnedRooms.Add(room);

                    }
                    else if(controller.spawnedRooms.Count + controller.toSpawn.Count > controller.NumberOfRooms)
                    {
                        GameObject room = Instantiate(controller.closedRoom, transform.position, Quaternion.identity);

                       
                    }
                    else
                    {
                        Debug.Log("Spawn random right");
                        int rand = Random.Range(0, controller.RightRooms.Length);

                        GameObject room = Instantiate(controller.RightRooms[rand], transform.position, Quaternion.identity);

                        controller.spawnedRooms.Add(room);
                    }

                }
                else if (spawnPointDirection == SpawnPoint.SpawnPointDirection.Right)
                {
                    if (controller.spawnedRooms.Count + controller.toSpawn.Count == controller.NumberOfRooms)
                    {
                        Debug.Log("Spawn a leftSingle");
                        GameObject room = Instantiate(controller.LeftSingle, transform.position, Quaternion.identity);

                        controller.spawnedRooms.Add(room);
                    }
                    else if (controller.spawnedRooms.Count + controller.toSpawn.Count > controller.NumberOfRooms)
                    {
                        GameObject room = Instantiate(controller.closedRoom, transform.position, Quaternion.identity);


                    }
                    else
                    {
                        Debug.Log("Spawn a random left");
                        int rand = Random.Range(0, controller.LeftRooms.Length);

                        GameObject room = Instantiate(controller.LeftRooms[rand], transform.position, Quaternion.identity);

                        controller.spawnedRooms.Add(room);
                    }

                }
                else if (spawnPointDirection == SpawnPoint.SpawnPointDirection.Top)
                {
                    if (controller.spawnedRooms.Count + controller.toSpawn.Count == controller.NumberOfRooms)
                    {
                        Debug.Log("Spawn a BottomSingle");
                        GameObject room = Instantiate(controller.BottomSingle, transform.position, Quaternion.identity);

                        controller.spawnedRooms.Add(room);
                    }
                    else if (controller.spawnedRooms.Count + controller.toSpawn.Count > controller.NumberOfRooms)
                    {
                        GameObject room = Instantiate(controller.closedRoom, transform.position, Quaternion.identity);


                    }
                    else
                    {
                        Debug.Log("Spawn a random bottom");
                        int rand = Random.Range(0, controller.BottomRooms.Length);

                        GameObject room = Instantiate(controller.BottomRooms[rand], transform.position, Quaternion.identity);

                        controller.spawnedRooms.Add(room);
                    }

                }
                else if (spawnPointDirection == SpawnPoint.SpawnPointDirection.Bottom)
                {
                    if (controller.spawnedRooms.Count + controller.toSpawn.Count == controller.NumberOfRooms)
                    {
                        Debug.Log("Spawn a topSingle");

                        GameObject room = Instantiate(controller.TopSingle, transform.position, Quaternion.identity);

                        controller.spawnedRooms.Add(room);
                    }
                    else if (controller.spawnedRooms.Count + controller.toSpawn.Count > controller.NumberOfRooms)
                    {
                        GameObject room = Instantiate(controller.closedRoom, transform.position, Quaternion.identity);


                    }
                    else
                    {

                        Debug.Log("Spawn a random top");
                        int rand = Random.Range(0, controller.TopRooms.Length);

                        GameObject room = Instantiate(controller.TopRooms[rand], transform.position, Quaternion.identity);

                        controller.spawnedRooms.Add(room);
                    }

                }
                if (controller.toSpawn.Contains(this))
                {
                    controller.toSpawn.Remove(this);
                }
                spawned = true;


            }
        }
    }
}
