using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoScroll : MonoBehaviour {

    public ScrollRect panel;

    private float delay = 0;
    private float timer = 0;
    private float delay2 = 0;
    private float relax = 30;


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(delay2);
        if (Input.GetAxis("Vertical") > 0.2)  //Scroll up
        {

            delay2++;
            if (delay2 > relax)
            {
                panel.verticalNormalizedPosition += 0.01f;
                delay = 120;
            }

        }
        else
        {
            if (Input.GetAxis("Vertical") < -0.2 && delay > 0)  //Scroll down
            {

                delay2++;
                if (delay2 > relax)
                {
                    panel.verticalNormalizedPosition -= 0.01f;
                    delay = 120;
                }

            }

            else
            {
                delay--;
                if (delay <= 0)  //Get back to the bottom
                {
                    panel.verticalNormalizedPosition = 0f;
                    timer = 0;
                    delay = 0;
                    delay2 = 0;
                }
            }

        }
    }
}
