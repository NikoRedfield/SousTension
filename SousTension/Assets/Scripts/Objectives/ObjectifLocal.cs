using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectifLocal : MonoBehaviour {

    public string text1;


    private Text mtext;
    private bool done;

	// Use this for initialization
	void Start () {
        mtext = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        ChangeDisplayedObjective();
	}

    void ChangeDisplayedObjective()
    {
    
        if(PlayerData.generators && !done)
        {
            mtext.text = text1;
            done = true;
        }

    }
}
