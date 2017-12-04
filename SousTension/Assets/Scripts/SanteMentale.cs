using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanteMentale : MonoBehaviour {

    public int diminution = 0;
    public GameObject Monster;

    private Slider slider;
    private int delay = 1;
    private int currentTime = 1;
    private GameObject cam;
    private bool changedOnce = false;
    private bool changedTwice = false;

	// Use this for initialization
	void Start () {
        slider = this.GetComponent<Slider>();
        cam = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.time >= currentTime)
        {
            currentTime += delay;
            Debug.Log(PlayerData.santeMentale);
            PlayerData.santeMentale -= diminution;
            slider.value = PlayerData.santeMentale;
        }
	}

    public void MentalHealthEvent()
    {
        if (slider.value <= 40 && !changedTwice)
        {
            changedTwice= true;
            Monster.transform.localScale = new Vector3(Monster.transform.localScale.x * 2, Monster.transform.localScale.y * 2, Monster.transform.localScale.z);
            return;
        }
        if (slider.value <= 80 && !changedOnce)
        {
            changedOnce = true;
           
             Monster.transform.localScale = new Vector3(Monster.transform.localScale.x * 2, Monster.transform.localScale.y , Monster.transform.localScale.z);
            
            //Monster.transform.localScale = Vector3.Lerp(Monster.transform.localScale, new Vector3(Monster.transform.localScale.x * 2, Monster.transform.localScale.y * 2, Monster.transform.localScale.z), Time.deltaTime);
           
            return;
        }
            if (slider.value <= 130)
        {
            Monster.SetActive(true);
            cam.GetComponent<CameraFollow2D>().enabled = false;
            cam.GetComponent<CameraScroll>().enabled = true;
            return;
        }
    }
}
