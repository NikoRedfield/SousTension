using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCamera : MonoBehaviour {

    public Camera cam;

    private bool stopped = false;
    
    //Center the camera on the player one last time
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!stopped)
        {
            cam.GetComponent<CameraScroll>().enabled = false;
            cam.GetComponent<CameraFollow2D>().enabled = true;
            stopped = true;
        }
    }

    //Stop any movement from the camera
    private void OnTriggerExit2D(Collider2D collision)
    {
        cam.GetComponent<CameraFollow2D>().enabled = false;

    }
}
