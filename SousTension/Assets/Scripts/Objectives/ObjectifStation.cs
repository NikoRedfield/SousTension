using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectifStation : MonoBehaviour {

    public string text1;
    public string text2;
    public string text3;

    private Text mtext;

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
        if(PlayerData.objective3 && !PlayerData.objective5)
        {
            mtext.text = text1;
        }
        if(PlayerData.objective3 && PlayerData.objective5 && !PlayerData.generators)
        {
            mtext.text = text2;
        }
        if(PlayerData.objective3 && PlayerData.objective5 && PlayerData.generators)
        {
            mtext.text = text3;
        }
    }
}
