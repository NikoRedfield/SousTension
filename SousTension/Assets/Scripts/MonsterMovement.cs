using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{

    public int speed = 1;


    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(new Vector3( speed * Time.deltaTime, 0, 0));  //Going forward at the given speed
    }
}

