using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depth : MonoBehaviour {

    private SpriteRenderer tempRed;

	// Use this for initialization
	void Awake () {
        tempRed = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        tempRed.sortingOrder = (int)Camera.main.WorldToScreenPoint(this.transform.position).y * -1;


	}
}
