using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAuthorisation : MonoBehaviour {

    public GameObject[] objectsToTest;

    private bool authorisation = true;
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        authorisation = CheckObjects();
        player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().SetAuthorisation(authorisation);
	}

    //Decides wether to block or not the access to the player's commands
    private bool CheckObjects()
    {
        foreach(GameObject element in objectsToTest)
        {
            if (element.activeSelf)
            {
                return true;
            }
        }
        return false;
    }
}
