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
    private bool spawned = false;
 

	// Use this for initialization
	void Start () {
        slider = this.GetComponent<Slider>();
        cam = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.timeSinceLevelLoad >= currentTime)
        {
            currentTime += delay;
            Debug.Log(PlayerData.santeMentale);
            PlayerData.santeMentale -= diminution;
            slider.value = PlayerData.santeMentale;
        }
            
	}

    public void MentalHealthEvent()
    {
        if (slider.value <= 30 && !changedTwice)
        {
            changedTwice= true;
            Monster.transform.localScale = new Vector3(Monster.transform.localScale.x, Monster.transform.localScale.y * 2, Monster.transform.localScale.z);
           // StartCoroutine(ScaleObject());
            return;
        }
        if (slider.value <= 80 && !changedOnce)
        {
            changedOnce = true;
            diminution--;
            Monster.transform.localScale = new Vector3(Monster.transform.localScale.x , Monster.transform.localScale.y , Monster.transform.localScale.z);
            //StartCoroutine(ScaleObject());
            //Monster.transform.localScale = Vector3.Lerp(Monster.transform.localScale, new Vector3(Monster.transform.localScale.x * 2, Monster.transform.localScale.y * 2, Monster.transform.localScale.z), Time.deltaTime);
           
            return;
        }
            if (slider.value <= 130 && !spawned)
        {
            spawned = true;
            Monster.SetActive(true);
            cam.GetComponent<CameraFollow2D>().enabled = false;
            cam.GetComponent<CameraScroll>().enabled = true;
            return;
        }
    }

    IEnumerator ScaleObject()
    {
        float scaleDuration = 2;                                //animation duration in seconds
        Vector3 actualScale = Monster.transform.localScale;             // scale of the object at the begining of the animation
        Vector3 targetScale = new Vector3(Monster.transform.localScale.x, Monster.transform.localScale.y *2, Monster.transform.localScale.z);     // scale of the object at the end of the animation

        for (float t = 0; t < 1; t += Time.deltaTime / scaleDuration)
        {
            Monster.transform.localScale = Vector3.Lerp(actualScale, targetScale, t);
            yield return null;
        }
    }
}
