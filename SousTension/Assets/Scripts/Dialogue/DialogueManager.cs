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
    public DialogueManager followUpDialogue = null;

    private Queue<Dialogue> Qdialogues;
    private Dialogue currentDialogue;

    private GameObject currentTextArea;
    private Text mtext;

    private bool choiceEngaged = false;

    private bool isLaunched = false;

    public GameObject portrait1;
    public GameObject portrait2;

    private bool dover = false;
    private GameObject player;

    //Initialiazing Queue Of Dialogue
    /* public void Awake()
     {
         currentTextArea = (GameObject)Instantiate(textArea);
         currentTextArea.transform.SetParent(panel);
         Qdialogues = new Queue<Dialogue>();
         mtext = currentTextArea.GetComponent<Text>();
     }*/

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    //Launching Dialogue
    public void StartDialogue()
    {
        isLaunched = true;

        if (isChoice)
        {
            gameObject.SetActive(true);
        }

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
        //mtext.text = mtext.text + "<size=16><color=white>   " + currentDialogue.sentence + "</color></size>\n\n\n";
        mtext.text += "<size=16><color=white></color></size>";
        StartCoroutine("PlayText");
    }

    //Continuing the dialogue to the next Sequence
    public void Update()
    {
        if (isLaunched)
        {

            if ((Input.GetKeyDown("space") || Input.GetButtonDown("Submit")) && dover)
            {
                dover = false;

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

                mtext.text = mtext.text + "<size=20><b><color=yellow>   " + currentDialogue.npcName + "</color></b></size>\n\n";
                // mtext.text = mtext.text + "<size=16><color=white>   " + currentDialogue.sentence + "</color></size>\n\n\n";
                mtext.text += "<size=16><color=white></color></size>";
                StartCoroutine("PlayText");
            }


        }
    }

    //Ending The Conversation
    private void EndDialogue()
    {
        if (hasChoice && dialogueUI.activeSelf)  //Launching the corresponding choice
        {
            choiceEngaged = true;
            choice.LaunchChoice();
            return;
        }
        if (followUpDialogue != null)
        {
            followUpDialogue.StartDialogue();
            Debug.Log("Follow up started");
            if (isChoice)
            {
                gameObject.SetActive(false);
            }
            //gameObject.SetActive(false);
            //return;
        }
        else
        {
            Debug.Log("Ending Conversation...");    //Ending the dialogue
            dialogueUI.SetActive(false);
            fadeLayout.SetActive(true);
            //fadeLayout.GetComponent<FadeManager>().Fade(false, 2f);
            choiceEngaged = false;
            player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().SetAuthorisation(true);
            if (isChoice)
            {
                gameObject.SetActive(false);  
            }
        }
    }


    IEnumerator PlayText()
    {
        float delay = 0f;
        foreach (char c in currentDialogue.sentence)
        {
            mtext.text = mtext.text.Substring(0, mtext.text.Length - 15) + c + mtext.text.Substring(mtext.text.Length - 15);
            if (!dover)
            {
                yield return new WaitForSeconds(delay);
            }
            if (Input.GetButtonDown("Submit") && !dover)
            {
                dover = true;
            }
        }
        mtext.text = mtext.text + "\n\n";
        dover = true;
    }


}
