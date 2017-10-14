﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        button1 = (GameObject)Instantiate(button);
        button1.transform.SetParent(panel);
        button1.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 50);

        button2 = (GameObject)Instantiate(button);
        button2.transform.SetParent(panel);
        button2.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 50);



        button1.GetComponentInChildren<Text>().text = Choice1;
        button2.GetComponentInChildren<Text>().text = Choice2;

        button1.GetComponent<Button>().onClick.AddListener(MakeChoice1);
        button2.GetComponent<Button>().onClick.AddListener(MakeChoice2);
    }

    public void MakeChoice1()
    {
        Debug.Log("Choice1");
        dialogueChoice1.SetActive(true);
        dialogueChoice1.GetComponent<DialogueManager>().StartDialogue();
        button2.SetActive(false);
        return;
    }

    public void MakeChoice2()
    {
        Debug.Log("Choice2");
        dialogueChoice2.SetActive(true);
        dialogueChoice2.GetComponent<DialogueManager>().StartDialogue();
        button1.SetActive(false);
        return;

    }
}
