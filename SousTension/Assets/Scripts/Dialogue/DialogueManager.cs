using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    //AddSpriteImage
    public GameObject textArea;

    public Dialogue[] dialogues;
    public GameObject dialogueUI;
    public bool hasChoice = false;
    public bool isChoice = false;
    public Choice choice;
    public GameObject fadeLayout;
    public RectTransform panel;

    private Queue<Dialogue> Qdialogues;
    private Dialogue currentDialogue;

    private GameObject currentTextArea;
    private Text mtext;

    private bool choiceEngaged = false;

    public GameObject portrait1;
    public GameObject portrait2;


    //Initialiazing Queue Of Dialogue
    /* public void Awake()
     {
         currentTextArea = (GameObject)Instantiate(textArea);
         currentTextArea.transform.SetParent(panel);
         Qdialogues = new Queue<Dialogue>();
         mtext = currentTextArea.GetComponent<Text>();
     }*/


    //Launching Dialogue
    public void StartDialogue()
    {
        

        currentTextArea = (GameObject)Instantiate(textArea);
        currentTextArea.transform.SetParent(panel);
        Qdialogues = new Queue<Dialogue>();
        mtext = currentTextArea.GetComponent<Text>();
        choiceEngaged = false;
    

        Debug.Log("Engaging a new conversation " );

        Qdialogues.Clear();

        foreach(Dialogue dialogue in dialogues)
        {
            Qdialogues.Enqueue(dialogue);

        }
        currentDialogue = Qdialogues.Dequeue();
        if(currentDialogue.npcName == "Gaius")
        {
            portrait2.SetActive(false);
            portrait1.SetActive(true);
        }
        else
        {
           portrait1.SetActive(false);
           portrait2.SetActive(true);
        }
        mtext.text += "\n";
        mtext.text = mtext.text + "<size=20><b><color=yellow>   " + currentDialogue.npcName + "</color></b></size>\n\n";
        mtext.text = mtext.text + "<size=16><color=white>   " + currentDialogue.sentence + "</color></size>\n\n\n";
    }

    //Continuing the dialogue to the next Sequence
    public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            fadeLayout.SetActive(false);
            if (Qdialogues.Count == 0)
            {
                if (!choiceEngaged)
                {
                    EndDialogue();
                }
                return;
            }
            currentDialogue = Qdialogues.Dequeue();
            if (currentDialogue.npcName == "Gaius")
            {
                portrait2.SetActive(false);
                portrait1.SetActive(true);
            }
            else
            {
                portrait1.SetActive(false);
                portrait2.SetActive(true);
            }

            mtext.text = mtext.text + "<size=20><b><color=yellow>   "+currentDialogue.npcName+"</color></b></size>\n\n";
            mtext.text = mtext.text+ "<size=16><color=white>   " + currentDialogue.sentence + "</color></size>\n\n\n";
        }  
        
       

    }

    //Ending The Conversation
    private void EndDialogue()
    {
        if (hasChoice && dialogueUI.activeSelf)
        {
            choiceEngaged = true;
           
            choice.LaunchChoice();
            return;
        }
        else
        {
            Debug.Log("Ending Conversation...");
            dialogueUI.SetActive(false);
            fadeLayout.SetActive(true);
            fadeLayout.GetComponent<FadeManager>().Fade(false, 2f);
            choiceEngaged = false;
            if (isChoice)
            {
                gameObject.SetActive(false);
            }
        }
    }

    
}
