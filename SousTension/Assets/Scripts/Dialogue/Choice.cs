using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Choice : MonoBehaviour {

    public string Choice1;
    public string Choice2;
 
    public GameObject dialogueChoice1;
    public GameObject dialogueChoice2;
    public DialogueManager followUpDialogue; 
    public GameObject button;
    public RectTransform panel;

    private GameObject button1;
    private GameObject button2;

   
   public void LaunchChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);  //Release the item selected by the event system

        button1 = (GameObject)Instantiate(button);   //Creates a new button based on the prefab
        button1.transform.SetParent(panel);  //Position the newly created button in the right panel
        button1.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 50);

        button2 = (GameObject)Instantiate(button);
        button2.transform.SetParent(panel);
        button2.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 50);



        button1.GetComponentInChildren<Text>().text = Choice1;
        button2.GetComponentInChildren<Text>().text = Choice2;

        button1.GetComponent<Button>().onClick.AddListener(MakeChoice1);  //Adds the behavior when clicked
        button2.GetComponent<Button>().onClick.AddListener(MakeChoice2);

        //EventSystem.current.firstSelectedGameObject = button1.gameObject;

        EventSystem.current.SetSelectedGameObject(button1.gameObject);
        button1.GetComponent<Button>().OnSelect(new BaseEventData(EventSystem.current)); // Highlight the button


    }

    public void MakeChoice1() //Using the first button
    {
        Debug.Log("Choice1");
        dialogueChoice1.SetActive(true); 
        dialogueChoice1.GetComponent<DialogueManager>().StartDialogue(); //Launching associated dialogue
        button2.SetActive(false); //Hide the unused choice
        button1.GetComponent<Button>().interactable = false; // Prevents the player from interacting again with the button
        return;
    }

    public void MakeChoice2()  //Using the second button
    {
        Debug.Log("Choice2");
        dialogueChoice2.SetActive(true);
        dialogueChoice2.GetComponent<DialogueManager>().StartDialogue();
        button1.SetActive(false);
        button2.GetComponent<Button>().interactable = false;
        return;

    }
}
