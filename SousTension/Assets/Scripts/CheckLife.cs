using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckLife : MonoBehaviour {

    public AudioClip deathClip;
    public FadeManager fade;

    private AudioSource source;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		if(PlayerData.santeMentale <= 20)
        {
            StartCoroutine(Death());
        }
	}


    //Loads GameOver Scene
    private IEnumerator Death()
    {
        source.clip = deathClip;
        source.Play();
        fade.Fade(false, 30f);
        yield return new WaitForSeconds(source.clip.length - 3);
        SceneManager.LoadScene("GameOver");
    }
}
