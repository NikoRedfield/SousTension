using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interaction : MonoBehaviour {

    public GameObject objectToEnable;       
    public FadeManager fade;
    public Narration dialogue;
    public GameObject controllerButton;  //UI for controller device
    public GameObject keyboardUI;   //UI for keyboard device

    private ControllerStatus controller;
    private bool interactionsEnabled = false;
    private GameObject displayedUI; //UI to display
    
    private int controllerState;
    private GameObject player;
    private bool alreadyTold = false;


    private void Start()
    {
        controller = this.GetComponent<ControllerStatus>();
        displayedUI = controllerButton;
        controllerState = controller.ControllerCheck();
        SwitchUi();
        player = GameObject.FindWithTag("Player");
    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        interactionsEnabled = true; //Enables interaction with character
        controllerState = controller.ControllerCheck();
        SwitchUi();
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        interactionsEnabled = false;  //Disables interaction with character
    }

	// Update is called once per frame
	void Update () {

        if (interactionsEnabled && !alreadyTold)// && player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().getAuthorisation())
        {
           
           displayedUI.SetActive(!objectToEnable.activeSelf);       //Displays the interaction UI

            if (Input.GetKeyDown("e") || Input.GetButtonDown("Submit"))
            {
                if (objectToEnable.activeSelf)  //Dialogue UI already displaying
                {
                    return;
                }
                fade.Fade(false, 2f);
                objectToEnable.SetActive(true);  //Displays Dialogue UI
               player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().backward = false;
                player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().SetAuthorisation(false);
                player.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().Move(0, false, false);
                Debug.Log("icic");
                dialogue.StartDialogue();
                alreadyTold = true;
            }
        }
        else
        {
            displayedUI.SetActive(false);  //Disables the interaction UI
           // objectToEnable.SetActive(false);

        }
       
		
	}

    //Checks what UI must be displayed on screen
    private void SwitchUi()
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
