using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour {

    public string Choice1;
    public string Choice2;
    public DialogueManager dialogueChoice1;
    public DialogueManager dialogueChoice2;
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



        button1.GetComponentInChildren<Text>().text = "1";
        button2.GetComponentInChildren<Text>().text = "2";
    }

    public void MakeChoice()
    {
        Debug.Log("OHKFDOGDFGOQ");
        
    }
}
