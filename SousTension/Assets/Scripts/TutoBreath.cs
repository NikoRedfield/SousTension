using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoBreath : MonoBehaviour {

    public GameObject TutorialBreath;

	// Use this for initialization
	void Start () {
        if (PlayerData.TutoBreath)
        {
            TutorialBreath.SetActive(true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().backward = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent <UnityStandardAssets._2D.Platformer2DUserControl > ().SetAuthorisation(false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().Move(0, false, false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (TutorialBreath.activeSelf)
        {
            if(Input.GetButton("Submit") || Input.GetKeyDown("c"))
            {
                PlayerData.TutoBreath = false;
                TutorialBreath.SetActive(false);
               
                GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().SetAuthorisation(true);
                this.gameObject.SetActive(false);
            }
        }
	}
}
