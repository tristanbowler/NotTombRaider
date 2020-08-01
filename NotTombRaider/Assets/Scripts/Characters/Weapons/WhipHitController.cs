using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipHitController : MonoBehaviour
{
    // Start is called before the first frame update
    public WhipController whipController;
    private void OnCollisionEnter(Collision other)
    {
        if (whipController.isSnap)
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Hit " + other.gameObject.name);
            }
        }
    }
}
