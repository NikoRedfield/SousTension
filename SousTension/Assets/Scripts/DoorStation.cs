using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorStation : MonoBehaviour {

    public string _nextLevel = "";
    public FadeManager fade;
    public float _delay = 1f;
    public GameObject controllerButton;
    public GameObject keyboardUI;
    public AudioClip clip;

    private bool canExit = false;
    private AudioSource source;
    private ControllerStatus controller;
    private GameObject displayedUI;
    private int controllerState;


    private void Start()
    {
        controller = this.GetComponent<ControllerStatus>();
        displayedUI = controllerButton;
        controllerState = controller.ControllerCheck();
        SwitchUI();
        source = this.GetComponent<AudioSource>();
        source.clip = clip;
        //DontDestroyOnLoad(fade.gameObject);
    }

    private  void OnTriggerEnter2D(Collider2D col)
    {
        canExit = true;
        controllerState = controller.ControllerCheck();
        SwitchUI();
    }

   private  void OnTriggerExit2D(Collider2D col)
    {
        canExit = false;
    }

    private void Update()
    {
        if(canExit)
        {
            displayedUI.SetActive(true);

            if (Input.GetKeyDown("e") || Input.GetButtonDown("Submit"))
            {
                
                StartCoroutine(FadeThenLoad());
            }
        }
        else
        {
            displayedUI.SetActive(false);
        }
    }

    private IEnumerator FadeThenLoad()
    {
        source.Play();
        fade.gameObject.SetActive(true);
        fade.Fade(false, 30f);
        yield return new WaitForSeconds(clip.length-1f);
        SceneManager.LoadScene(_nextLevel);
    }

    private void SwitchUI()
    {
        switch (controllerState)
        {
            case 0:
                displayedUI = keyboardUI;
                break;
            case 1:
                displayedUI = controllerButton;
                break;

            default:
                Debug.Log("Error on SwitchUI");
                break;
        }
    }

}
