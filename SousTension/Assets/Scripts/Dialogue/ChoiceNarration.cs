using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChoiceNarration : MonoBehaviour
{

    public string Choice1;
    public string Choice2;

    public GameObject dialogueChoice1;
    public GameObject dialogueChoice2;
    
    public GameObject button;
    public RectTransform panel;

    public Narration followUpDialogue = null;

    public int impactChoice1 = 0;
    public int impactChoice2 = 0;
    
    private GameObject button1;
    private GameObject button2;

    private Slider smBar;

    void Start()
    {
        smBar = GameObject.Find("SanteMentale").GetComponent<Slider>();
    }



    public void LaunchChoice()
    {
        Debug.Log(PlayerData.santeMentale);

        EventSystem.current.SetSelectedGameObject(null);

        button1 = (GameObject)Instantiate(button);
        button1.transform.SetParent(panel);
        button1.GetComponent<RectTransform>().sizeDelta = new Vector2(380, 20);

        button2 = (GameObject)Instantiate(button);
        button2.transform.SetParent(panel);
        button2.GetComponent<RectTransform>().sizeDelta = new Vector2(380, 50);



        button1.GetComponentInChildren<Text>().text = Choice1;
        button1.GetComponentInChildren<Text>().fontSize = 20;
        button2.GetComponentInChildren<Text>().text = Choice2;
        button2.GetComponentInChildren<Text>().fontSize = 20;

        button1.GetComponent<Button>().onClick.AddListener(MakeChoice1);
        button2.GetComponent<Button>().onClick.AddListener(MakeChoice2);

        //EventSystem.current.firstSelectedGameObject = button1.gameObject;

        EventSystem.current.SetSelectedGameObject(button1.gameObject);
        // Highlight the button
        button1.GetComponent<Button>().OnSelect(new BaseEventData(EventSystem.current));

       // anim.enabled = true;
        //animChoice.enabled = true;
        
        //anim.Play("MoveBack");
        //animChoice.Play("MovePanel");

    }

    public void MakeChoice1()
    {
       // anim.Play("MoveLeft");
        //animChoice.Play("MovePanelBack");
        Debug.Log("Choice1");
        dialogueChoice1.SetActive(true);
        dialogueChoice1.GetComponent<Narration>().StartDialogue();
        button2.SetActive(false);
        button1.GetComponent<Button>().interactable = false;
        
        PlayerData.santeMentale += impactChoice1;
        smBar.value = PlayerData.santeMentale;
        Debug.Log(PlayerData.santeMentale);

        return;
    }

    public void MakeChoice2()
    {
        //anim.Play("MoveLeft");
        //animChoice.Play("MovePanelBack");
        Debug.Log("Choice2");
        dialogueChoice2.SetActive(true);
        dialogueChoice2.GetComponent<Narration>().StartDialogue();
        button1.SetActive(false);
        button2.GetComponent<Button>().interactable = false;

        PlayerData.santeMentale += impactChoice2;
        smBar.value = PlayerData.santeMentale;

        Debug.Log(PlayerData.santeMentale);

        return;

    }

}
