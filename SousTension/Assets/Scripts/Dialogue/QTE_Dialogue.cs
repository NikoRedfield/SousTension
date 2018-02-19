using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class QTE_Dialogue : MonoBehaviour {

    public Image img1;
    public Image img2;
    public Sprite[] touchesKey;
    public Sprite[] touchedButtons;
    public GameObject[] linkedObjects;
    public GameObject UI;
    public Narration FollowupDialogue;
    public bool animated;

    private bool begin;
    private int i;
    private bool over = false;
    private GameObject player;
    private ControllerStatus controller;
    private int controllerState;
    private Sprite[] touches;

    // Use this for initialization
    void Start () {
        i = 0;
        controller = this.GetComponent<ControllerStatus>();
        touches = touchesKey;
        controllerState = controller.ControllerCheck();
        SwitchBoard();     //Switch UI depending on the device used
    }
	
	// Update is called once per frame
	void Update () {
        controllerState = controller.ControllerCheck();
        SwitchBoard();     
        DisplayUI();
        ActionQTE();
	}


    void DisplayUI()
    {
        UI.SetActive(true);
        if (i + 1 < touches.Length)
        {
            img1.sprite = touches[i];
            img2.sprite = touches[i + 1];
        }
    }

    void ActionQTE()
    {
        switch (i)
        {
            case 0:
                if(Input.GetButton("QTE_feu") && Input.GetAxis("Vertical") < 0)
                {
                    i += 2;
                }
                break;

            case 2:
                if (Input.GetButton("QTE_feu") && Input.GetAxis("Horizontal") < 0)
                {
                    i += 2;
                }
                break;

            case 4:
                if (Input.GetButton("QTE_feu") && Input.GetAxis("Horizontal") > 0)
                {
                    i += 2;
                }
                break;

            case 6:
                if (Input.GetButton("QTE_feu") && Input.GetAxis("Horizontal") < 0)
                {
                    i += 2;
                }
                break;


            case 8:
                if (Input.GetButton("QTE_feu") && Input.GetAxis("Horizontal") > 0)
                {
                    i += 2;
                }
                break;

            case 10:
                if (Input.GetButton("QTE_feu") && Input.GetAxis("Horizontal") < 0)
                {
                    i += 2;
                }
                break;

            case 12:
                if (Input.GetButton("QTE_feu") && Input.GetAxis("Horizontal") > 0)
                {
                    i += 2;
                }
                break;

            case 14:
                if (Input.GetButton("QTE_feu") && Input.GetAxis("Vertical") > 0)
                {
                    i += 2;
                }
                break;

            default:
                Win();
                break;
        }
    }

    void Win()
    {
        Debug.Log("WinQTE");
        foreach (GameObject objects in linkedObjects)
        {
            objects.SetActive(true);
        }
        UI.SetActive(false);
        FollowupDialogue.StartDialogue();
        if (animated)
        {
            this.GetComponent<AnimFeu>().SetFixed();
        }
        gameObject.SetActive(false);
    }

    //Check what UI to display
    private void SwitchBoard()
    {
        switch (controllerState)
        {
            case 0:
                touches = touchesKey;
                break;
            case 1:
                touches = touchedButtons;
                break;

            default:
                Debug.Log("Error on SwitchUI");
                break;
        }
    }
}
