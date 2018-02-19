using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaisseBarrier : MonoBehaviour {

    public BoxCollider2D solidCollider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            solidCollider.isTrigger = true;
        }
        else
        {
            solidCollider.isTrigger = false;
        }
    }
}
