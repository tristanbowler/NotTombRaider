using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Room : MonoBehaviour
{
    // Start is called before the first frame update
    public List<SpawnPoint> SpawnPoints;
    private RoomGenerationController controller;
    public int spawnOrder = -1;
    public TextMeshProUGUI orderLabel;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("RoomsController").GetComponent<RoomGenerationController>();
        //Invoke("SpawnAdjacents", 0.01f);
    }

    public void SetSpawnOrder(int order)
    {
        spawnOrder = order;
        orderLabel.text = spawnOrder.ToString();
    }

    private void SpawnAdjacents()
    {
        foreach(SpawnPoint point in SpawnPoints)
        {
            if(controller.spawnedRooms.Count > 100)
            {
                break;
            }
            
            if(point.spawnPointDirection == SpawnPoint.SpawnPointDirection.Left)
            {
                int rand = Random.Range(0, controller.RightRooms.Length);
                Vector3 position = point.transform.position;
                Destroy(point.gameObject);
                GameObject room = Instantiate(controller.RightRooms[rand]);
                room.transform.position = position;
                controller.spawnedRooms.Add(room);
                List<SpawnPoint> points = room.GetComponent<Room>().SpawnPoints;
                foreach(SpawnPoint newPoint in points)
                {
                    if(newPoint.spawnPointDirection == SpawnPoint.SpawnPointDirection.Right)
                    {
                        room.GetComponent<Room>().SpawnPoints.Remove(newPoint);
                        break;
                    }
                }
            }
            else if (point.spawnPointDirection == SpawnPoint.SpawnPointDirection.Right)
            {
                int rand = Random.Range(0, controller.LeftRooms.Length);
                Vector3 position = point.transform.position;
                Destroy(point.gameObject);
                GameObject room = Instantiate(controller.LeftRooms[rand]);
                room.transform.position = position;
                controller.spawnedRooms.Add(room);

                List<SpawnPoint> points = room.GetComponent<Room>().SpawnPoints;
                 foreach (SpawnPoint newPoint in points)
                 {
                     if (newPoint.spawnPointDirection == SpawnPoint.SpawnPointDirection.Left)
                     {
                         room.GetComponent<Room>().SpawnPoints.Remove(newPoint);
                         break;
                     }
                 }
            }
            else if (point.spawnPointDirection == SpawnPoint.SpawnPointDirection.Top)
            {
                int rand = Random.Range(0, controller.BottomRooms.Length);
                Vector3 position = point.transform.position;
                Destroy(point.gameObject);
                GameObject room = Instantiate(controller.BottomRooms[rand]);
                room.transform.position = position;
                controller.spawnedRooms.Add(room);

                List<SpawnPoint> points = room.GetComponent<Room>().SpawnPoints;
                foreach (SpawnPoint newPoint in points)
                {
                    if (newPoint.spawnPointDirection == SpawnPoint.SpawnPointDirection.Bottom)
                    {
                        room.GetComponent<Room>().SpawnPoints.Remove(newPoint);
                        break;
                    }
                }
            }
            else if (point.spawnPointDirection == SpawnPoint.SpawnPointDirection.Bottom)
            {
                int rand = Random.Range(0, controller.TopRooms.Length);
                Vector3 position = point.transform.position;
                Destroy(point.gameObject);
                GameObject room = Instantiate(controller.TopRooms[rand]);
                room.transform.position = position;
                controller.spawnedRooms.Add(room);

                List<SpawnPoint> points = room.GetComponent<Room>().SpawnPoints;
                 foreach (SpawnPoint newPoint in points)
                 {
                     if (newPoint.spawnPointDirection == SpawnPoint.SpawnPointDirection.Top)
                     {
                         room.GetComponent<Room>().SpawnPoints.Remove(newPoint);
                         break;
                     }
                 }
            }
            
        }
    }
}
