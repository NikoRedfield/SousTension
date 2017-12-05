using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothScale : MonoBehaviour {

    private float speed = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(this.transform.localScale.x, this.transform.localScale.y * 2, this.transform.localScale.z), speed * Time.deltaTime);
    }
}
