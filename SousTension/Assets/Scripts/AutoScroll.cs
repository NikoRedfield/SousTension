using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoScroll : MonoBehaviour {

    public ScrollRect panel;

    private float delay = 0;
    private float timer = 0;
   
    
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Vertical") > 0)
        {
            panel.verticalNormalizedPosition += 0.01f;
            delay = 3;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            panel.verticalNormalizedPosition -= 0.01f;
            delay = 3;
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > delay)
            {
                panel.verticalNormalizedPosition = 0f;
                timer = 0;
                delay = 0;
            }
        }
      
	}
}
