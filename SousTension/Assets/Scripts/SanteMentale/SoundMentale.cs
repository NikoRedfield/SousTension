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
        if (PlayerData.santeMentale < 130)
        {
            frequence = PlayerData.santeMentale + 50;
        }
        else
        {
            frequence = 0;
        }
    }
}
