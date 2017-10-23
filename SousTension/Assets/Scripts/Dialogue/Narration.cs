﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Narration : MonoBehaviour
{

    //AddSpriteImage
    public GameObject textArea;

    public Dialogue[] dialogues;
    public GameObject dialogueUI;
    public bool hasChoice = false;
    public bool isChoice = false;
    public ChoiceNarration choice;
    public GameObject fadeLayout;
    public RectTransform panel;
    public Narration followUpDialogue = null;

    private Queue<Dialogue> Qdialogues;
    private Dialogue currentDialogue;

    private GameObject currentTextArea;
    private Text mtext;

    private bool choiceEngaged = false;

    private bool isLaunched = false;

    private bool dover = false;


    //Launching Dialogue
    public void StartDialogue()
    {
        isLaunched = true;

        currentTextArea = (GameObject)Instantiate(textArea);
        currentTextArea.transform.SetParent(panel);
        Qdialogues = new Queue<Dialogue>();
        mtext = currentTextArea.GetComponent<Text>();
        choiceEngaged = false;

        EventSystem.current.SetSelectedGameObject(currentTextArea.gameObject);


        Debug.Log("Engaging a new conversation ");

        Qdialogues.Clear();

        foreach (Dialogue dialogue in dialogues)
        {
            Qdialogues.Enqueue(dialogue);

        }
        currentDialogue = Qdialogues.Dequeue();

        if (currentDialogue.npcName != "")
        {
            mtext.text += "\n";
            mtext.text = mtext.text + "<size=20><b><color=yellow>   " + currentDialogue.npcName + "</color></b></size>\n\n";
        }
        //mtext.text = mtext.text + "<size=16><color=white>   ";
        StartCoroutine("PlayText");
       // mtext.text += currentDialogue.sentence;
       // mtext.text = mtext.text + "</color></size>\n\n";
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

                if (currentDialogue.npcName != "")
                {
                    mtext.text = mtext.text + "<size=20><b><color=yellow>   " + currentDialogue.npcName + "</color></b></size>\n\n";
                }
               // mtext.text = mtext.text + "<size=16><color=white>   " + currentDialogue.sentence + "</color></size>\n\n";
                StartCoroutine("PlayText"); 
            }


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
        if (followUpDialogue != null)
        {
            followUpDialogue.StartDialogue();
            Debug.Log("Follow up started");
            if (isChoice)
            {
                gameObject.SetActive(false);
            }
  
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
            SceneManager.LoadScene("Dialogue2");
        }
    }

    IEnumerator PlayText()
    {
        float delay = 0f;
        foreach (char c in currentDialogue.sentence)
        {
            mtext.text += "<size=16><color=white>";
            mtext.text += c;
            mtext.text = mtext.text + "</color></size>";
            if(!dover) {
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
