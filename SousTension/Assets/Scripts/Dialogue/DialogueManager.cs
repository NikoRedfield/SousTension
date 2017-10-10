using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text nText;
    public Text dText;
    public Dialogue dialogue;
    public GameObject dialogueUI;
    public bool singleChoice = true;

    private Queue<string> sentences;
    

    //Initialiazing Queue Of Dialogue
    public void Start()
    {
        sentences = new Queue<string>();
    }

    //Launching Dialogue
    public void StartDialogue()
    {
        Debug.Log("Engaging a new conversation with " + dialogue.npcName);

        nText.text = dialogue.npcName;


        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }

        DisplayNextSentence();
    }

    //Continuing the dialogue to the next Sequence
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
       
        switch(sentence)
        {
            case "choice1":
                //Launch one choice
                break;
            case "choice2":
                //Launch two choices
                break;
            case "choice3":
                //Launch three choices
                break;
            case "choice4":
                //Launch four choices
                break;
            default:
                dText.text = sentence;
                break;
        }
    }

    //Ending The Conversation
    private void EndDialogue()
    {
        Debug.Log("Ending Conversation...");
        dialogueUI.SetActive(false);
    }
}
