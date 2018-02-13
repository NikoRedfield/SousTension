using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedArrow : MonoBehaviour {

    public int max;
    public int min;

    private bool up = true;
	
	// Update is called once per frame
	void Update () {
        if (this.transform.localPosition.y >=max)
        {
            up = false;
            Debug.Log("Reached max");
        }
        if(this.transform.localPosition.y <= min)
        {
            up = true;
        }
        if (up)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 3f, this.transform.position.z);
        }
        if(!up)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 3f, this.transform.position.z);
        }
	}
}
