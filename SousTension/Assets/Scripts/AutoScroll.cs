using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoScroll : MonoBehaviour {

    public ScrollRect panel;

    private float delay = 4;
    private float timer = 0;
    
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Vertical") > 0)
        {
            panel.verticalNormalizedPosition += 0.01f;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            panel.verticalNormalizedPosition -= 0.01f;
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > delay)
            {
                panel.verticalNormalizedPosition = 0f;
                timer = 0;
            }
        }
      
	}
}
