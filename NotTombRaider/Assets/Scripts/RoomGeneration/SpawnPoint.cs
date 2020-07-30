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
    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("RoomsController").GetComponent<RoomGenerationController>();
        Invoke("SpawnRoom", 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SpawnPoint"))
        {
            Destroy(gameObject);
        }
    }

    private void SpawnRoom()
    {
        if (!spawned)
        {
            if (spawnPointDirection == SpawnPoint.SpawnPointDirection.Left)
            {
                int rand = Random.Range(0, controller.RightRooms.Length);
                
                GameObject room = Instantiate(controller.RightRooms[rand], transform.position, Quaternion.identity);
                
                controller.spawnedRooms.Add(room);

            }
            else if (spawnPointDirection == SpawnPoint.SpawnPointDirection.Right)
            {
                int rand = Random.Range(0, controller.LeftRooms.Length);
                
                GameObject room = Instantiate(controller.LeftRooms[rand], transform.position, Quaternion.identity);
                
                controller.spawnedRooms.Add(room);

            }
            else if (spawnPointDirection == SpawnPoint.SpawnPointDirection.Top)
            {
                int rand = Random.Range(0, controller.BottomRooms.Length);
                
                GameObject room = Instantiate(controller.BottomRooms[rand], transform.position, Quaternion.identity);
                
                controller.spawnedRooms.Add(room);

            }
            else if (spawnPointDirection == SpawnPoint.SpawnPointDirection.Bottom)
            {
                int rand = Random.Range(0, controller.TopRooms.Length);
                
                GameObject room = Instantiate(controller.TopRooms[rand], transform.position, Quaternion.identity);
                
                controller.spawnedRooms.Add(room);

            }
            spawned = true;
        }
    }
}
