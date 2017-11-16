using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

    public float speed = 2;


    void OnTriggerStay2D(Collider2D col)
    {
            if (Input.GetAxis("Vertical") > 0)  //Going up the ladder
            {
                //Debug.Log("FUUUUUUUU");
                col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            }
            else if (Input.GetAxis("Vertical") < 0) //Going down the ladder
        {
            //Debug.Log("FUUUUUUUU");
            col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
        }
        else
            {
                col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);   //Lowering gravity impact while idle on the ladder
            }
    }


}
