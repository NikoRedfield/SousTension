using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnEnter : MonoBehaviour {

    public string nextLevel;
    public AudioClip clip;      //Exit SFX
    public FadeManager fade;

    private AudioSource source;

    // Use this for initialization
    void Start () {
        source = this.GetComponent<AudioSource>();
        source.clip = clip;
    }
	
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter!");
        StartCoroutine(FadeThenLoad());
    }

    //Exit the current level and load the next one
    private IEnumerator FadeThenLoad()
    {
        source.Play();
        fade.gameObject.SetActive(true);
        fade.Fade(false, 30f);
        yield return new WaitForSeconds(clip.length - 2f);
        PlayerData.previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(nextLevel);
    }
}
