using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    //AddSpriteImage
    public Text mtext;

    public Dialogue[] dialogues;
    public GameObject dialogueUI;
    public bool hasChoice = false;
    public Choice choice;

    private Queue<Dialogue> Qdialogues;
    private Dialogue currentDialogue;
    
    

    //Initialiazing Queue Of Dialogue
    public void Start()
    {
        Qdialogues = new Queue<Dialogue>();
    }

    //Launching Dialogue
    public void StartDialogue()
    {
        Debug.Log("Engaging a new conversation " );

        Qdialogues.Clear();

        foreach(Dialogue dialogue in dialogues)
        {
            Qdialogues.Enqueue(dialogue);

        }
        currentDialogue = Qdialogues.Dequeue();
        mtext.text += "\n";
        mtext.text = mtext.text + "<size=20><b><color=yellow>   " + currentDialogue.npcName + "</color></b></size>\n\n";
        mtext.text = mtext.text + "<size=16><color=white>   " + currentDialogue.sentence + "</color></size>\n\n\n";
    }

    //Continuing the dialogue to the next Sequence
    public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (Qdialogues.Count == 0)
            {
                EndDialogue();
                return;
            }
            currentDialogue = Qdialogues.Dequeue();
           
            mtext.text = mtext.text + "<size=20><b><color=yellow>   "+currentDialogue.npcName+"</color></b></size>\n\n";
            mtext.text = mtext.text+ "<size=16><color=white>   " + currentDialogue.sentence + "</color></size>\n\n\n";
        }  
        
       

    }

    //Ending The Conversation
    private void EndDialogue()
    {
        if (hasChoice)
        {
            choice.LaunchChoice();
        }
        Debug.Log("Ending Conversation...");
        dialogueUI.SetActive(false);
    }
}
