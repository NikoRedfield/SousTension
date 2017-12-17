using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour {

    public Animator anim;
    public int delay = 50;
    private int timer;

	// Use this for initialization
	void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer++;
        if(timer > delay)
        {
            anim.Play("Train",10,0F);
            delay *= 2;
        }
	}
}
