using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicQTE : MonoBehaviour {

    public GameObject[] linkedObjects;  //Objects linked to the QTE
    public string QTEinput = "Submit";  //Input used to interact 
    public int numberPressed = 1;   //Number of Inputs necessary for validation
    public GameObject controllerButton;    //Controlelr UI used 
    public GameObject keyboardButton; //Keyboard UI used
    public Image fillMeter;     
    public AudioClip mainSound;
    public AudioClip successSound;
    public bool linkedToMonster = false;
    public Sprite[] Buttons;
    public Sprite[] Keys;
    public Sprite disjoncteurClosed;
    public Sprite disjoncteurOpen;
    public GameObject CheckGenerators;
    public GameObject FillEmpty;

    private int valideInput = 0;    //Current number of correct inputs
    private AudioSource source;
    private bool authoriseInput = false;
    private ControllerStatus controller;  //Check the used input device
    private GameObject displayedUI;
    private int controllerState;
    private int spriteIndex = 0;
    private bool fixedGen = false;

    // Use this for initialization
    void Start () {
        controller = this.GetComponent<ControllerStatus>();
        displayedUI = controllerButton;
        controllerState = controller.ControllerCheck();
        SwitchUI();     //Switch UI depending on the device used

        // valideInput = 0;
        source = this.GetComponent<AudioSource>();
        source.clip = mainSound;
	}


    //Display and authorise both UI and input listener
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "Player")
        {
            if (valideInput < numberPressed)    //QTE not yet validated
            {
                this.GetComponent<SpriteRenderer>().sprite = disjoncteurOpen;
                controllerState = controller.ControllerCheck();
                SwitchUI();
                InvokeRepeating("AnimateUI", 0, 0.1f);
                authoriseInput = true;
                displayedUI.SetActive(true);
                fillMeter.gameObject.SetActive(true);
                FillEmpty.SetActive(true);
                fillMeter.fillAmount = 0;
            }
        }
   
    }

    //Cancel both UI and inputs related to the QTE 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(valideInput < numberPressed)
            {
                valideInput = 0;
            }
            this.GetComponent<SpriteRenderer>().sprite = disjoncteurClosed;
            CancelInvoke();
            authoriseInput = false;
            displayedUI.SetActive(false);
            fillMeter.gameObject.SetActive(false);
            FillEmpty.SetActive(false);
        }
    }

    //Listen to the Inputs
    private void Update()
    {
        if (authoriseInput && valideInput < numberPressed)
        {
            displayedUI.SetActive(true);
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
               displayedUI.SetActive(false);
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
        this.GetComponent<SpriteRenderer>().sprite = disjoncteurClosed;
        CancelInvoke();
        foreach(GameObject objects in linkedObjects)
        {
            objects.SetActive(true);
        }
        if (CheckGenerators != null)
        {
            CheckGenerators.GetComponent<CountGenerator>().AddGenerator();
        }
    }

    //Success Feedback
    private IEnumerator PlaySoundThenDisable()
    {
        source.Stop();
        source.clip = successSound;
        source.Play();
        SuccessQTE();
        yield return new WaitForSeconds(successSound.length);
        fillMeter.gameObject.SetActive(false);
    }

    //Check what UI to display
    private void SwitchUI()
    {
        switch (controllerState)
        {
            case 0:
                displayedUI = keyboardButton;
                break;
            case 1:
                displayedUI = controllerButton;
                break;

            default:
                Debug.Log("Error on SwitchUI");
                break;
        }
    }

    void AnimateUI()
    {
        displayedUI.SetActive(true);
        Debug.Log("entered coroutine");
        if (displayedUI.Equals(keyboardButton))
        {
            displayedUI.GetComponent<Image>().sprite = Keys[spriteIndex];
            spriteIndex++;
            if(spriteIndex > 2)
            {
                spriteIndex = 0;
            }
            Debug.Log("Sprite : "+ spriteIndex);
            
        }
        else
        {
            displayedUI.GetComponent<Image>().sprite = Buttons[spriteIndex];
            spriteIndex++;
            if (spriteIndex > 2)
            {
                spriteIndex = 0;
            }
            Debug.Log("Sprite : " + spriteIndex);

        }
      


    }


}
