using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {


    public AudioClip EnterSound;
    public AudioClip FadeSound;
    public string LevelToLoad = "Level01";
    public FadeManager fade;
    public GameObject deactivate;
    public Button button;

    private AudioSource source;


    void Awake()
    {
        Cursor.visible = true;
        Time.timeScale = 1; //In case of pause menu during the game before getting back to the main menu
        source = GetComponent<AudioSource>();
       
        source.clip = EnterSound;
        //DontDestroyOnLoad(fade);
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
        button.interactable = false;
        deactivate.SetActive(false);
        //source.clip = FadeSound;
        //fade.gameObject.SetActive(true);
       // fade.Fade(false, 25f);
        source.Play();
        yield return new WaitForSeconds(1f);  //WaitForSeconds(5f)
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

    //Load the main menu without any other FX
    public void PlayAgain()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
 