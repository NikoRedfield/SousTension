using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightArrowAppear : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        if (PlayerData.Ejournal)
        {
            this.GetComponent<Image>().enabled = true;
        }
        else
        {
            this.GetComponent<Image>().enabled = false;
        }
	}
}
