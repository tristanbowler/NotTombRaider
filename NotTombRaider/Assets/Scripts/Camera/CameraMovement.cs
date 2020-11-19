using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform thief;
    public Transform fighter;
    private Camera mainCamera;
    public float zoomFactor = 1.5f;
    public float followTimeDelta = 0.8f;
    public float maxHeight = 14;
    public float minHeight = 10;
    private Vector3 newCameraDestination;
    private Vector3 oldCameraDestination;


    private void Start()
    {
        mainCamera = Camera.main;
        thief = GameObject.FindGameObjectWithTag("Player1").transform;
        fighter = GameObject.FindGameObjectWithTag("Player2").transform;
    }

    private void Update()
    {
        FixedCameraFollowSmooth();
    }

    public void FixedCameraFollowSmooth()
    {
        

        // Midpoint we're after
        Vector3 midpoint = (thief.position + fighter.position) / 2f;

        // Distance between objects
        float distance = (thief.position - fighter.position).magnitude;

        //newCameraDestination = midpoint - mainCamera.transform.forward * distance * zoomFactor;
        newCameraDestination = midpoint - mainCamera.transform.forward *  zoomFactor;

        if (newCameraDestination.y >= maxHeight)
        {
            newCameraDestination = oldCameraDestination;
            newCameraDestination.y = maxHeight;

        }
        else
        {
            oldCameraDestination = newCameraDestination;
        }
        if (newCameraDestination.y <= minHeight)
        {
            newCameraDestination.y = minHeight;

        }






        // Adjust ortho size if we're using one of those
        if (mainCamera.orthographic)
        {
            // The camera's forward vector is irrelevant, only this size will matter
            mainCamera.orthographicSize = distance;
        }
        

        // Snap when close enough to prevent annoying slerp behavior
        if ((newCameraDestination - mainCamera.transform.position).magnitude <= 0.05f)
        {
            mainCamera.transform.position = newCameraDestination;
        }      
        else
        {
            Vector3 moveTowards = Vector3.MoveTowards(mainCamera.transform.position, newCameraDestination, followTimeDelta);
            if (newCameraDestination.y >= maxHeight)
            {
                moveTowards.y = maxHeight;
            }
            if (newCameraDestination.y <= minHeight)
            {
                moveTowards.y = minHeight;
            }

            mainCamera.transform.position = moveTowards;
        }
    }
}
