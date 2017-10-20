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
        Time.timeScale = 1; //In case of pause menu during the game before getting back to the main menu
        source = GetComponent<AudioSource>();
       
        source.clip = EnterSound;
    }


    //Launch new game
    public void NewGame()
    {
        //SceneManager.LoadScene(LevelToLoad);
        StartCoroutine(PlaySoundThenLoad());
    }

    //Plays the button sound effect before loading the next scene
    public IEnumerator PlaySoundThenLoad()
    {
        source.Play();
        yield return new WaitForSeconds(source.clip.length);
        SceneManager.LoadScene(LevelToLoad);
       
    }

    //Plays the button sound effect before closing the game
    public IEnumerator PlaySoundThenQuit()
    {
        source.Play();
        yield return new WaitForSeconds(source.clip.length);
        Application.Quit();

    }

    //Exit The Game
    public void QuitGame()
    {
        StartCoroutine(PlaySoundThenQuit());
    }
}
