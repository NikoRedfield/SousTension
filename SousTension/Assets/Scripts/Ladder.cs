using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

    public float speed = 2;

   // private bool isClimbing = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
      

    }

    void OnTriggerStay2D(Collider2D col)
    {

       // if (Input.GetButtonDown("Submit"))
        //{
         //   isClimbing = true;
        //}

      //  if (isClimbing)
        //{
            if (Input.GetAxis("Vertical") > 0)
            {
                Debug.Log("FUUUUUUUU");
                col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            }
            else
            {
                col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        //}
    }

  /*  void onTriggerExit()
    {
        isClimbing = false;
    }*/
}
