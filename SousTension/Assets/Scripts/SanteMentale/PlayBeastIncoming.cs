using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBeastIncoming : MonoBehaviour {

    public AudioClip MonsterIncoming;

    private bool done;
    private bool started;
    private AudioSource source;

    private void Start()
    {
        source = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        if (PlayerData.santeMentale <= (int)PlayerData.maxSanteMentale * 0.24 && PlayerData.santeMentale >= PlayerData.maxSanteMentale * 0.05)
        {
            if (!started)
            {
                source.volume = 1;
                source.clip = MonsterIncoming;
                source.loop = true;
                source.Play();
                started = true;
                done = false;
            }
        }
        else
        {
            if(PlayerData.santeMentale >= PlayerData.maxSanteMentale * 0.24)
            {
                source.Stop();
            }
            if (!done)
            {
                //source.Stop();
                done = true;
                started = false;
            }
        }

    }

}
