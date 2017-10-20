using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {

    public GameObject objectToEnable;
    public FadeManager fade;
    public DialogueManager dialogue;
    public GameObject controllerButton;
    

    private bool interactionsEnabled = false;
 
    

    public void OnTriggerEnter2D(Collider2D col)
    {
        interactionsEnabled = true; //Enables interaction with character
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        interactionsEnabled = false;  //Disables interaction with character
    }

	// Update is called once per frame
	void Update () {

        if (interactionsEnabled)
        {
           
            controllerButton.SetActive(!objectToEnable.activeSelf);       //Displays the interaction UI

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
            controllerButton.SetActive(false);  //Disables the interaction UI
        }
       
		
	}
}
