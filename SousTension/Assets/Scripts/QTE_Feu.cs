using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTE_Feu : MonoBehaviour {

    public Image img1;
    public Image img2;
    public Sprite[] touches;
    public GameObject[] linkedObjects;

    private bool begin;
    private int i;

	// Use this for initialization
	void Start () {
        begin = false;
        i = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (begin)
        {
            DisplayUI();
            ActionQTE();
        }
	}


    void DisplayUI()
    {
        img1.gameObject.SetActive(true);
        img2.gameObject.SetActive(false);
        img1.sprite = touches[i];
        img2.sprite = touches[i + 1];
    }

    void ActionQTE()
    {
        switch (i)
        {
            case 0:
                if(Input.GetButton("QTE_feu") && Input.GetAxis("Horizontal") < 0)
                {
                    i += 2;
                }
                break;

            case 2:
                if (Input.GetButton("QTE_feu") && Input.GetAxis("Vertical") < 0)
                {
                    i += 2;
                }
                break;

            case 4:
                if (Input.GetButton("QTE_feu") && Input.GetAxis("Vertical") > 0)
                {
                    i += 2;
                }
                break;

            case 6:
                if (Input.GetButton("QTE_feu") && Input.GetAxis("Vertical") < 0)
                {
                    i += 2;
                }
                break;


            case 8:
                if (Input.GetButton("QTE_feu") && Input.GetAxis("Vertical") > 0)
                {
                    i += 2;
                }
                break;

            case 10:
                if (Input.GetButton("QTE_feu") && Input.GetAxis("Vertical") < 0)
                {
                    i += 2;
                }
                break;

            case 12:
                if (Input.GetButton("QTE_feu") && Input.GetAxis("Vertical") > 0)
                {
                    i += 2;
                }
                break;

            case 14:
                if (Input.GetButton("QTE_feu") && Input.GetAxis("Horizontal") > 0)
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
        foreach (GameObject objects in linkedObjects)
        {
            objects.SetActive(true);
        }
    }
}
