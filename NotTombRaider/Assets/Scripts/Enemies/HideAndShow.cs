using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAndShow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Hide();
    }

    public void Hide()
    {
        Renderer[] rends = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rends)
        {
            r.enabled = false;
        }

        
    }
    public void Show()
    {
        Renderer[] rends = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rends)
        {
            r.enabled = true;
        }

        
    }
}
