using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    
    void Start()
    {
        this.transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.back, Camera.main.transform.rotation * Vector3.up);
        this.transform.Rotate(0, 180, 0);
    }

    
    void Update()
    {
        this.transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.back, Camera.main.transform.rotation * Vector3.up);
        this.transform.Rotate(0, 180, 0);
    }
}
