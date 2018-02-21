using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lungs2 : MonoBehaviour
{

    public GameObject lungs; //Main UI
    public GameObject lung1; //MiniLung on the side when success
    public GameObject lung2;
    public GameObject lung3;
    public Image air; //Radial bar
    public GameObject UIkeyboard;
    public GameObject UIcontroller;
    public AudioClip BreathingSound;
    public int restrictedUse = 1;
    

    private int times; //times required
    private int cTimes; //current times
    private int relax;
    private bool begin;
    private int targetRelax;
    private int bonus;
    private int timer;
    private GameObject UItoDisplay;
    private ControllerStatus controller;
    private int controllerState;
    private AudioSource source;
    private int currentTimesUsed;
    



    void Start()
    {
        source = this.GetComponent<AudioSource>();
        source.clip = BreathingSound;
        times = 3;
        cTimes = 0;
        relax = 0;
        begin = false;
        targetRelax = 60;
        bonus = 100;
        timer = 20;
        controller = this.GetComponent<ControllerStatus>();
        controllerState = controller.ControllerCheck();
        SwitchUI();
        currentTimesUsed = 0;
    }


    void Update()
    {

        if (PlayerData.santeMentale > 15 && currentTimesUsed < restrictedUse)  //Restrain the availability of the breathing feature to sm > 15
        {
            if (!lungs.activeSelf)
            {
                if ((Input.GetButton("Lungs1") && Input.GetButtonDown("Lungs2")) || (Input.GetAxis("Lungs3") > 0 && Input.GetAxis("Lungs4") > 0) && timer == 0)  //&& !begin)
                {
                    controllerState = controller.ControllerCheck();
                    SwitchUI();
                    lungs.SetActive(true);
                    source.Play();
                    air.gameObject.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    if (timer > 0)
                    {
                        timer--;
                    }
                }
            }
            else
            {
                Breath();
                if (Input.GetButtonDown("Cancel")|| Input.GetAxisRaw("Horizontal") != 0)
                {
                    Reset();
                    
                }
            }
        }
    }



    void Breath()
    {
        if (TestLungs())
        {
            air.fillAmount += 0.01f;
            lungs.transform.localScale = new Vector3(lungs.transform.localScale.x + 0.003f, lungs.transform.localScale.y + 0.003f, lungs.transform.localScale.z);
        }
        if (!TestLungs())
        {
            UItoDisplay.SetActive(true);
            Debug.Log("!TestLungs()");
            if ((Input.GetButton("Lungs1") && Input.GetButton("Lungs2")) || (Input.GetAxis("Lungs3") > 0 && Input.GetAxis("Lungs4") > 0))
            {
                cTimes++;
                DisplayLungs();
                air.fillAmount = 0;
                UItoDisplay.SetActive(false);
                lungs.transform.localScale = new Vector3(0.5f, 0.5f, lungs.transform.localScale.z);
                if (cTimes == times)
                {
                    Win();
                }
              
            }
            else
            {
                relax++;
                if (relax >= targetRelax)
                {
                    Failed();
                }
            }
        }


    }

    bool TestLungs()
    {
        if (air.fillAmount >= 1)
        {
            return false;
        }
        return true;
    }

    void Win()
    {
       
        Debug.Log("win");
        PlayerData.santeMentale += bonus;
        Reset();
        currentTimesUsed++;
    }

    void Failed()
    {
        air.fillAmount = 0;
        lungs.transform.localScale = new Vector3(0.5f, 0.5f, lungs.transform.localScale.z);
       begin = false;
        relax = 0;
        UItoDisplay.SetActive(false);
        Debug.Log("Failed");
    }

    void DisplayLungs()
    {
        if (lung1.activeSelf)
        {
            if (lung2.activeSelf)
            {
                lung3.SetActive(true);
            }
            else
            {
                lung2.SetActive(true);
            }
        }
        else
        {
            lung1.SetActive(true);
        }
    }

    private void Reset()
    {
        UItoDisplay.SetActive(false);
        source.Stop();
        air.gameObject.SetActive(true);
        lungs.transform.localScale = new Vector3(0.5f, 0.5f, lungs.transform.localScale.z);
        lungs.SetActive(false);
        lung1.SetActive(false);
        lung2.SetActive(false);
        lung3.SetActive(false);
        begin = false;
        cTimes = 0;
        air.fillAmount = 0;
        Time.timeScale = 1;
        timer = 20;
        air.gameObject.SetActive(false);
    }

    //Check what UI to display
    private void SwitchUI()
    {
        switch (controllerState)
        {
            case 0:
                UItoDisplay = UIkeyboard;
                break;
            case 1:
                UItoDisplay = UIcontroller;
                break;

            default:
                Debug.Log("Error on SwitchUI");
                break;
        }
    }
}
