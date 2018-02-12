using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMentale : MonoBehaviour {

    public AudioClip[] clips;

    private AudioSource source;
    private int frequence;
    private int innerDelay;

	// Use this for initialization
	void Start () {
        frequence = 0;
        innerDelay = 0;
        source = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckSanteMentale();
        if(frequence != 0)
        {
            if (!source.isPlaying)
            {
                if (innerDelay >= frequence)
                {
                    innerDelay = 0;
                    PlayRandomSound();
                }
                innerDelay++;
            }
        }
	}

    void PlayRandomSound()
    {
        int choice = (int)Random.Range(0, clips.Length);
        source.clip = clips[choice];
        source.Play();
    }

    void CheckSanteMentale()
    {
        if (PlayerData.santeMentale <= (int)PlayerData.maxSanteMentale * 0.50 && PlayerData.santeMentale >= PlayerData.maxSanteMentale * 0.35)
        {
            frequence = 900;
            return;
        }
        if (PlayerData.santeMentale <= (int)PlayerData.maxSanteMentale * 0.34 && PlayerData.santeMentale >= (int)PlayerData.maxSanteMentale * 0.25)
        {
            frequence = 600;
            return;
        }
        if (PlayerData.santeMentale <= PlayerData.maxSanteMentale * 0.24 && PlayerData.santeMentale >= (int)PlayerData.maxSanteMentale * 0.05)
        {
            frequence = 420;
            return;
        }
        else
        {
            // Debug.Log("0 bulle");
            frequence = 0;
        }
    }
}
