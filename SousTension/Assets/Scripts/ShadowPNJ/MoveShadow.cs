using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShadow : MonoBehaviour {

    public int min;
    public int max;

    private bool left;
   

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (left)
        {
            if(this.transform.position.x < min)
            {
                this.GetComponent<UnityStandardAssets._2D.PNJmovement>().Move(0, false, false);
                Destroy(this.gameObject);
            }
            else
            {
                this.GetComponent<UnityStandardAssets._2D.PNJmovement>().Move(-1, false, false);
            }
        }
        else
        {
            if (this.transform.position.x > max)
            {
                this.GetComponent<UnityStandardAssets._2D.PNJmovement>().Move(0, false, false);
                Destroy(this.gameObject);
            }
            else
            {
                this.GetComponent<UnityStandardAssets._2D.PNJmovement>().Move(1, false, false);
            }
        }
	}

    public void SetLeft(bool value)
    {
        this.left = value;
    }
}
