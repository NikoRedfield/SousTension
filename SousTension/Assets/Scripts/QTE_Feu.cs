using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class QTE_Feu : MonoBehaviour {

    public Image img1;
    public Image img2;
    public Sprite[] touchesKey;
    public Sprite[] touchedButtons;
    public GameObject[] linkedObjects;
    public GameObject UI;

    private bool begin;
    private int i;
    private bool over = false;
    private GameObject player;
    private ControllerStatus controller;
    private int controllerState;
    private Sprite[] touches;

    // Use this for initialization
    void Start () {
        begin = false;
        i = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        controller = GameObject.Find("Manager").GetComponent<ControllerStatus>();
        touches = touchesKey;
        controllerState = controller.ControllerCheck();
        SwitchBoard();     //Switch UI depending on the device used
    }
	
	// Update is called once per frame
	void Update () {
        if (begin)
        {
            DisplayUI();
            ActionQTE();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!over)
        {
            begin = true;
            player.GetComponent<Platformer2DUserControl>().SetAuthorisation(false);
           // Time.timeScale = 0;
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        begin = false;
        UI.SetActive(false);
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
        begin = false;
        UI.SetActive(false);
        player.GetComponent<Platformer2DUserControl>().SetAuthorisation(true);
        over = true;
       // Time.timeScale = 1;
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
