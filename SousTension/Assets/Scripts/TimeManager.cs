using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    public int startHour;
    public int startMinute;

    private float minute;
    private int hour;
    private Text mtext;
   

	// Use this for initialization
	void Start () {
        mtext = GetComponent<Text>();
        hour = startHour;
        minute = startMinute;
      
	}
	
	// Update is called once per frame
	void Update () {
        ChangeTime();
        if(minute < 10)
        {
            mtext.text = hour + " : 0" + (int)minute;
        }
        else
        {
            mtext.text = hour + " : " + (int)minute;
        }
	}

    void ChangeTime()
    {
        minute += Time.deltaTime;
        if((int)minute >= 60)
        {
            hour += 1;
            minute = 0;
        }
    }

    //Manually Skip a certain amount of time
    void SkipTime(int min)
    {

    }
}
