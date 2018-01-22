using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorStation : MonoBehaviour {

    public string _nextLevel = "";   //Next level to load
    public FadeManager fade;
    public float _delay = 1f;   //Fade Delay
    public GameObject controllerButton;  //Controller UI
    public GameObject keyboardUI;       //Keyboard UI
    public AudioClip clip;      //Door SFX

    private bool canExit = false;   //Enable the player to reach the next level
    private AudioSource source;
    private ControllerStatus controller;  //Check the used input device
    private GameObject displayedUI; 
    private int controllerState;
    private GameObject player;


    private void Start()
    {
        controller = this.GetComponent<ControllerStatus>();
        displayedUI = controllerButton;
        controllerState = controller.ControllerCheck();
        SwitchUI();     //Switch UI depending on the device used
        source = this.GetComponent<AudioSource>();
        source.clip = clip;
        player = GameObject.FindWithTag("Player");
    }

    //enables exit
    private  void OnTriggerEnter2D(Collider2D col)
    {
        canExit = true;
        controllerState = controller.ControllerCheck();
        SwitchUI();
        Debug.Log(PlayerData.santeMentale);
    }

    //disables exit
   private  void OnTriggerExit2D(Collider2D col)
    {
        canExit = false;
    }

    private void Update()
    {
        if(canExit && player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().getAuthorisation())
        {
            displayedUI.SetActive(true);

            if(Input.GetAxis("Vertical") > 0)
            //if (Input.GetKeyDown("e") || Input.GetButtonDown("Submit"))
            {
                
                StartCoroutine(FadeThenLoad()); //Launch EXIT
            }
        }
        else
        {
            displayedUI.SetActive(false);
        }
    }

    //Exit the current level and load the next one
    private IEnumerator FadeThenLoad()
    {
        source.Play();
        fade.gameObject.SetActive(true);
        fade.Fade(false, 30f);
        yield return new WaitForSeconds(clip.length-1f);
        SceneManager.LoadScene(_nextLevel);
    }

    //Check what UI to display
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
