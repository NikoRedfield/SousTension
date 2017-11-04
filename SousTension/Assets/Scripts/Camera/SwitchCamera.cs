using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwitchCamera : MonoBehaviour {

    public Camera cam;
  

    private CameraScroll auto;
    private CameraFollow2D follow;
    private bool switched;

    private void Start()
    {
        auto = cam.GetComponent<CameraScroll>();
        follow = cam.GetComponent<CameraFollow2D>();
        switched = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!switched)
        {
            Debug.Log("Switch ! ");
           auto.enabled = !auto.enabled;
            follow.enabled = !follow.enabled;
            switched = true;
        }
    }
}
