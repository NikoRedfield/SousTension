using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingAudio : MonoBehaviour {

    public AudioClip HappyEnd;
    public AudioClip End;

    private AudioSource source;
    
	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(transform.gameObject);
        source = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        ChangeMusic();
	}

    void PlayHappy()
    {
        if(source.clip != HappyEnd)
        {
            source.clip = HappyEnd;
        }
        if (!source.isPlaying)
        {
            source.Play();
        }
    }

    void PlayEnd()
    {
        if (source.clip != End)
        {
            source.clip = End;
        }
        if (!source.isPlaying)
        {
            source.Play();
        }
    }

    void ChangeMusic()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene.Equals("Bonus"))
        {
            PlayHappy();
        }
        if (currentScene.Equals("Conclusion"))
        {
            if(PlayerData.Sang1 && PlayerData.Journal1)
            {
                PlayHappy();
            }
            else
            {
                PlayEnd();
            }
        }
        if (currentScene.Equals("End"))
        {
            if (PlayerData.Sang1 && PlayerData.Journal1)
            {
                PlayHappy();
            }
            else
            {
                PlayEnd();
            }
        }
        if (currentScene.Equals("Menu"))
        {
            Destroy(transform.gameObject);
        }
    }
}
