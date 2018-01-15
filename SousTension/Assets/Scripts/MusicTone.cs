using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTone : MonoBehaviour {

    public AudioSource[] sources;
    
    private AudioSource currentSource;
    private AudioSource oldsource;
	
	// Update is called once per frame
	void Update () {
		
	}

   public void SwitchAudio(AudioSource newSource)
    {       
        foreach(AudioSource a in sources)
        {
            a.volume = 0;
        }
        newSource.volume = 1;
    }
}
