using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInsta : MonoBehaviour {

    public AudioClip clipCrescendo;
    public AudioClip breakSFX;
    public AudioClip monsterTheme;
    public GameObject monster;

    private AudioSource source;
    private int monsterFinalSize; //The width the monster must acquire in order to be considered into his final form
    private GameObject cam;
    private int monsterInitSize;
    private bool began;


	void Start () {
        began = false;
        source = this.GetComponent<AudioSource>();
        cam = GameObject.Find("Main Camera");
        monsterFinalSize = 5;
        monsterInitSize = 0;
        if (PlayerData.santeMentale <= 0)
        {
            this.GetComponent<MonsterNewForm>().enabled = false;
            source.clip = monsterTheme;
            source.volume = 1;
            source.Play();
            source.loop = true;
        }
        else
        {
            this.enabled = false;
        }
       
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.timeSinceLevelLoad > 9 && !began)
        {
            LaunchInstantAttack();
            began = true;
        }
        if (PlayerData.santeMentale >= PlayerData.maxSanteMentale * 7 /100)
        {
            ResetFeedback();
        }
	}


    private void ResetFeedback()
    {
        monster.transform.localScale = new Vector3(monsterInitSize, monster.transform.localScale.y, monster.transform.localScale.z);
        monster.SetActive(false);
        source.volume = 0;
        source.Stop();
        if (!cam.GetComponent<CameraFollow2D>().enabled)
        {
            SwitchCamera();
        }
        this.GetComponent<MonsterNewForm>().enabled = true;
        this.enabled = false;
    }

    private void SwitchCamera()
    {
        if (cam.GetComponent<CameraFollow2D>().enabled)
        {
            cam.GetComponent<CameraFollow2D>().enabled = false;
            cam.GetComponent<CameraScroll>().enabled = true;
        }
        else
        {
            cam.GetComponent<CameraFollow2D>().enabled = true;
            cam.GetComponent<CameraScroll>().enabled = false;
        }
    }

    private void LaunchInstantAttack()
    {
        monster.transform.localScale = new Vector3(monsterFinalSize, monster.transform.localScale.y, monster.transform.localScale.z);
        monster.SetActive(true);
        SwitchCamera();
    }
}
