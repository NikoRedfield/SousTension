using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCommands : MonoBehaviour {

    private int maxSanteMentale = PlayerData.maxSanteMentale;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("1"))
        {
            PlayerData.santeMentale = (int) maxSanteMentale * 80 /100;
        }
        if (Input.GetKeyDown("2"))
        {
            PlayerData.santeMentale = (int) maxSanteMentale * 60 / 100;
        }
        if (Input.GetKeyDown("3"))
        {
            PlayerData.santeMentale = (int) maxSanteMentale * 40 / 100;
        }
        if (Input.GetKeyDown("4"))
        {
            PlayerData.santeMentale = (int) maxSanteMentale * 20 / 100;
        }
        if (Input.GetKeyDown("5"))
        {
            PlayerData.santeMentale = (int)maxSanteMentale * 8 / 100;
        }
    }
}
