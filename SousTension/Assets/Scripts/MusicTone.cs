using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTone : MonoBehaviour {

    public AudioSource[] sources;
    
    private AudioSource currentSource;
    private AudioSource oldsource;
    private int currentLVL;

    private void Start()
    {
        currentLVL = 0;
    }


   public void SwitchAudio(int impact)
    {
        currentLVL += impact;
        if(currentLVL > 0)
        {
            currentLVL = 0;
        }
        if(currentLVL < -2)
        {
            currentLVL = -2;
        }
        foreach(AudioSource a in sources)
        {
            a.volume = 0;
        }
        switch (currentLVL)
        {
            case 0:
                sources[0].volume = 1;
                break;
            case -1:
                sources[1].volume = 1;
                break;
            case -2:
                sources[2].volume = 1;
                break;
            default:
                Debug.Log("Error on switching audio feature");
                break;
        }
    }

    public int GetCurrentLVL()
    {
        return this.currentLVL;
    }
}
