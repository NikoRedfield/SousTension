using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

    public float speed = 6;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
      

    }

    void OnTriggerStay2D(Collider2D col)
    {
       // float v = Input.GetAxis("Vertical");
        if (Input.GetKeyDown("z"))
        {
            Debug.Log("FUUUUUUUU");
            col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        }
    }
}
