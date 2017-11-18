using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicRandomly : MonoBehaviour {

    public AudioClip[] clips;

    private AudioSource source;
    private int maxRange;
    private int index;

	
	void Start () {
        maxRange = clips.Length;
        index = 0;
        source = this.GetComponent<AudioSource>();
        SelectRandomClip();
	}
	
	/*
	void Update () {
        if (!source.isPlaying)
        {
            SelectRandomClip();
        }
	}

    */

    private void SelectRandomClip()
    {
        index = Random.Range(0, maxRange-1);
        source.clip = clips[index];
        source.Play();
        source.loop = true;

    }
}
