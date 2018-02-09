using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour {

    public GameObject ShadowImage;

    private int posInit;
    private bool started;
    private int duration;
    private int timelaps;
    private int frequence;
    private int innerDelay;

	// Use this for initialization
	void Start () {
        started = false;
        timelaps = 600;
        innerDelay = 0;
	}
	
	// Update is called once per frame
	void Update () {
        CheckFrequence();
        if(frequence != 0 && !started)
        {
            if(innerDelay> frequence)
            {
                Move();
                innerDelay = 0;
            }
            innerDelay++;
        }
        if (started)
        {
            ShadowImage.transform.position = new Vector3(ShadowImage.transform.position.x + 40, ShadowImage.transform.position.y, ShadowImage.transform.position.z);
            duration++;
            if(duration > timelaps)
            {
                ResetFeedback();
            }
        }
	}

    void Move()
    {
        ShadowImage.SetActive(true);
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x - Screen.width);
        pos.y = Mathf.Clamp01(pos.y);
        ShadowImage.transform.position = Camera.main.ViewportToWorldPoint(pos);
        started = true;
    }

    void CheckFrequence()
    {
        if(PlayerData.santeMentale <= PlayerData.maxSanteMentale * 24 / 100 && PlayerData.santeMentale >= PlayerData.maxSanteMentale * 10 / 100)
        {
            frequence = 560;
        }
        if (PlayerData.santeMentale <= PlayerData.maxSanteMentale * 9 / 100 && PlayerData.santeMentale >= PlayerData.maxSanteMentale * 5 / 100)
        {
            frequence = 300;
        }
        else
        {
            frequence = 0;
        }
    }

    void ResetFeedback()
    {
        started = false;
        ShadowImage.SetActive(false);
    }
}
