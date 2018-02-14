using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouPicked : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().backward = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().SetAuthorisation(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().Move(0, false, false);
        if (Input.GetButton("Submit") || Input.GetKeyDown("c"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().SetAuthorisation(true);
            this.gameObject.SetActive(false);
        }
    }
}
