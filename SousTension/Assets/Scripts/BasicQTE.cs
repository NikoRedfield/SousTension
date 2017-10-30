using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicQTE : MonoBehaviour {

    public GameObject[] linkedObjects;
    public string QTEinput = "Submit";
    public int numberPressed = 1;
    public GameObject QTEui;
    public Image fillMeter;
    public AudioClip mainSound;
    public AudioClip successSound;

    private int valideInput = 0;
    private AudioSource source;
    private bool authoriseInput = false;

	// Use this for initialization
	void Start () {
        // valideInput = 0;
        source = this.GetComponent<AudioSource>();
        source.clip = mainSound;
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (valideInput < numberPressed)
        {
            authoriseInput = true;
            QTEui.SetActive(true);
            fillMeter.gameObject.SetActive(true);
            fillMeter.fillAmount = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        authoriseInput = false;
        QTEui.SetActive(false);
        fillMeter.gameObject.SetActive(false);
    }

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
        if (Input.GetButtonDown(QTEinput))
            {
            if (!source.isPlaying)
            {
                source.Play();
            }
            valideInput += 1;
            fillMeter.fillAmount += (1/(float)numberPressed);
            Debug.Log("Pressed");
        }
        if(valideInput == numberPressed)
            {
                SuccessQTE();
                QTEui.SetActive(false);
            StartCoroutine(PlaySoundThenDisable());
           
            authoriseInput = false;
            }
    }

    private void SuccessQTE()
    {
        foreach(GameObject objects in linkedObjects)
        {
            objects.SetActive(true);
        }
    }

    private IEnumerator PlaySoundThenDisable()
    {
        source.Stop();
        source.clip = successSound;
        source.Play();
        yield return new WaitForSeconds(successSound.length);
        fillMeter.gameObject.SetActive(false);
    }
}
