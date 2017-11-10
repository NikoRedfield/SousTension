using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interaction : MonoBehaviour {

    public GameObject objectToEnable;
    public FadeManager fade;
    public DialogueManager dialogue;
    public GameObject controllerButton;
    public GameObject keyboardUI;

    private ControllerStatus controller;
    private bool interactionsEnabled = false;
    private GameObject displayedUI;
    
    private int controllerState;


    private void Start()
    {
        controller = this.GetComponent<ControllerStatus>();
        displayedUI = controllerButton;
        controllerState = controller.ControllerCheck();
        SwitchUi();
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

        if (interactionsEnabled)
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
                dialogue.StartDialogue();
            }
        }
        else
        {
            displayedUI.SetActive(false);  //Disables the interaction UI
        }
       
		
	}

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
