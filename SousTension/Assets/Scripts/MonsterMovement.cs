using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{

    public int speed = 1;
    public bool StuckToCamera = true;
    public bool StuckToCameraRight = false;

    // Update is called once per frame
    void Update()
    {
        if (StuckToCamera)
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp01(pos.x);
            pos.y = Mathf.Clamp01(pos.y);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }
        if (StuckToCameraRight)
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp01(pos.x + Screen.width);
            pos.y = Mathf.Clamp01(pos.y);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }
        else
        {
            this.gameObject.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));  //Going forward at the given speed
        }
        
    }
}

