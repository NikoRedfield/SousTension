using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text nText;
    public Text dText;

    private Queue<string> sentences;
    

    //Initialiazing Queue Of Dialogue
    public void Start()
    {
        sentences = new Queue<string>();
    }

    //Launching Dialogue
    public void StartDialogue(Dialogue dialogue)
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
        dText.text = sentence;
    }

    //Ending The Conversation
    private void EndDialogue()
    {
        Debug.Log("Ending Conversation...");
    }
}
