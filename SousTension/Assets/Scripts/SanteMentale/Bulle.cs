using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bulle : MonoBehaviour {

    public GameObject bulle;
    public string[] mtexts;

    private bool authorise;
    private bool begun;
    private int delay;
    private float frequence;
    private int defaultDelay = 200;
    private int randText;
    private float innerDelay;


	// Use this for initialization
	void Start () {
        begun = false;
        delay = defaultDelay;
        innerDelay = 0;
	}
	
	// Update is called once per frame
	void Update () {
        CheckSanteMentale();
        if (frequence != 0)
        {
            if (!begun)
            {
                //Debug.Log("f = " + frequence + " delay = " + innerDelay);
                innerDelay++;
                if(innerDelay >= frequence)
                {
                    innerDelay = 0;
                    DisplayBulle();
                }  
            }
            else
            {
                CheckOver();
            }
        }
	}


    void DisplayBulle()
    {
        begun = true;
        bulle.SetActive(true);
        randText = (int)Random.Range(0, mtexts.Length);
        bulle.GetComponentInChildren<Text>().text = mtexts[randText];     
    }

    void CheckOver()
    {
        if(delay <= 0)
        {
            bulle.SetActive(false);
            begun = false;
            delay = defaultDelay;
        }
        else
        {
            delay--;
        }
    }

    void CheckSanteMentale()
    {
        if(PlayerData.santeMentale < 270)
        {
            frequence = PlayerData.santeMentale + 50;// / 5;
            if(frequence < 0)
            {
                frequence = 5;
            }
        }
        else
        {
            frequence = 0;
        }
    }

    
}
