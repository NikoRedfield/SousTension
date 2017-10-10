using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {


    public AudioClip EnterSound;
    public string LevelToLoad = "Level01";
   

    private AudioSource source;


    void Awake()
    {
        Cursor.visible = true;
        Time.timeScale = 1;
        source = GetComponent<AudioSource>();
       
        source.clip = EnterSound;
    }

    public void NewGame()
    {
        //SceneManager.LoadScene(LevelToLoad);
        StartCoroutine(PlaySoundThenLoad());
    }

    public IEnumerator PlaySoundThenLoad()
    {
        source.Play();
        yield return new WaitForSeconds(source.clip.length);
        SceneManager.LoadScene(LevelToLoad);
       
    }

    public IEnumerator PlaySoundThenQuit()
    {
        source.Play();
        yield return new WaitForSeconds(source.clip.length);
        Application.Quit();

    }


    public void QuitGame()
    {
        StartCoroutine(PlaySoundThenQuit());
    }
}
