using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCommands : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("1"))
        {
            PlayerData.santeMentale = (int) PlayerData.santeMentale * 80 /100;
        }
        if (Input.GetKeyDown("2"))
        {
            PlayerData.santeMentale = (int)PlayerData.santeMentale * 60 / 100;
        }
        if (Input.GetKeyDown("3"))
        {
            PlayerData.santeMentale = (int)PlayerData.santeMentale * 40 / 100;
        }
        if (Input.GetKeyDown("4"))
        {
            PlayerData.santeMentale = (int)PlayerData.santeMentale * 20 / 100;
        }
    }
}
