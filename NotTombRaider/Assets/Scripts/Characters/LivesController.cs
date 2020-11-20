using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour
{
    public GameObject Thief;
    public GameObject Fighter;

    private void Start()
    {
        Thief = GameObject.FindGameObjectWithTag("Player1");
        Fighter = GameObject.FindGameObjectWithTag("Player2");
    }
}
