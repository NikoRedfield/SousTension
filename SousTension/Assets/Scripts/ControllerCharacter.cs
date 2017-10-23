using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCharacter : MonoBehaviour {

    int speed = 40;


    void Update()
    {
        if (Input.GetAxis("Horizontal")!=0)
        {
            transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetAxis("Vertical")!=0)
        {
            transform.Translate(new Vector3(0, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0));
        }

    }
}
