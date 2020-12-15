using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBool : MonoBehaviour
{
    public Animator animator;
    public string boolName;
    public bool setTo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        
        if(animator.GetBool(boolName) == !setTo)
        {
            animator.SetBool(boolName, setTo);
        }
    }
}
