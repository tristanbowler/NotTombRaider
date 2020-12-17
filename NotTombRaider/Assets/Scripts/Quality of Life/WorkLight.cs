using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkLight : MonoBehaviour
{
    public bool isDark;
    // Start is called before the first frame update
    void Start()
    {
        if (isDark)
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
