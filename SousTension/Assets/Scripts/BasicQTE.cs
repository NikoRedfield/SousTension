using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicQTE : MonoBehaviour {

    public GameObject[] linkedObjects;  //Objects linked to the QTE
    public string QTEinput = "Submit";  //Input used to interact 
    public int numberPressed = 1;   //Number of Inputs necessary for validation
    public GameObject QTEui;    //UI used 
    public Image fillMeter;     
    public AudioClip mainSound;
    public AudioClip successSound;
    public bool linkedToMonster = false;

    private int valideInput = 0;    //Current number of correct inputs
    private AudioSource source;
    private bool authoriseInput = false;

	// Use this for initialization
	void Start () {
        // valideInput = 0;
        source = this.GetComponent<AudioSource>();
        source.clip = mainSound;
	}


    //Display and authorise both UI and input listener
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (valideInput < numberPressed)    //QTE not yet validated
        {
            authoriseInput = true;
            QTEui.SetActive(true);
            fillMeter.gameObject.SetActive(true);
            fillMeter.fillAmount = 0;
        }
    }

    //Cancel both UI and inputs related to the QTE 
    private void OnTriggerExit2D(Collider2D collision)
    {
        authoriseInput = false;             
        QTEui.SetActive(false);
        fillMeter.gameObject.SetActive(false);
    }

    //Listen to the Inputs
    private void Update()
    {
        if (authoriseInput && valideInput < numberPressed)
        {
            QTEui.SetActive(true);
            fillMeter.gameObject.SetActive(true);
            LaunchQTE();
        }
    }


    private void LaunchQTE()
    {
        //Debug.Log("launching qte");
        if (Input.GetButtonDown(QTEinput))  //If the user input is the one asked by the QTE
            {
            if (!source.isPlaying)
            {
                source.Play();  //Plays the sound of the QTE Interaction
            }
            valideInput += 1;   //Increase the number of correct inputs known
            fillMeter.fillAmount += (1/(float)numberPressed); //Increase the fill meter
           // Debug.Log("Pressed");
        }
        if(valideInput == numberPressed)   //If the required number of inputs has been reached
            {
                //SuccessQTE();   //Launch the success sequence
                QTEui.SetActive(false);
            if (linkedToMonster)
            {
                GameObject.Find("Monster").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.Find("Main Camera").GetComponent<CameraFollow2D>().enabled = true;
                GameObject.Find("Main Camera").GetComponent<CameraScroll>().enabled = false;
            }
            StartCoroutine(PlaySoundThenDisable());
           
            authoriseInput = false;  //Deativate the input listener
            }
    }

    //Activate all the objects linked to the QTE
    private void SuccessQTE()
    {
        foreach(GameObject objects in linkedObjects)
        {
            objects.SetActive(true);
        }
    }

    //Success Feedback
    private IEnumerator PlaySoundThenDisable()
    {
        source.Stop();
        source.clip = successSound;
        source.Play();
        yield return new WaitForSeconds(successSound.length);
        SuccessQTE();
        fillMeter.gameObject.SetActive(false);
    }
}
