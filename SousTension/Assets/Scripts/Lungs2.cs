using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lungs2 : MonoBehaviour
{

    public GameObject lungs;
    public GameObject lung1;
    public GameObject lung2;
    public GameObject lung3;
    public Image air;

    private int times;
    private int cTimes;
    private int relax;
    private bool begin;
    private int targetRelax;
    private int bonus;
    private int timer;



    void Start()
    {
        times = 3;
        cTimes = 0;
        relax = 0;
        begin = false;
        targetRelax = 60;
        bonus = 30;
        timer = 20;
    }


    void Update()
    {
        if (!lungs.activeSelf)
        {
            if ((Input.GetButton("Lungs1") && Input.GetButtonDown("Lungs2")) || (Input.GetAxis("Lungs3") > 0 && Input.GetAxis("Lungs4") > 0) && timer == 0)  //&& !begin)
            {
                lungs.SetActive(true);
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
            if (Input.GetButtonDown("Cancel"))
            {
                Reset();
            }
        }
    }



    void Breath()
    {
        if (TestLungs())
        {
            air.fillAmount += 0.01f;  
        }
        if (!TestLungs())
        {
            Debug.Log("!TestLungs()");
            if ((Input.GetButton("Lungs1") && Input.GetButton("Lungs2")) || (Input.GetAxis("Lungs3") > 0 && Input.GetAxis("Lungs4") > 0))
            {
                cTimes++;
                DisplayLungs();
                air.fillAmount = 0;
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
    }

    void Failed()
    {
        air.fillAmount = 0;
        begin = false;
        relax = 0;
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
        lungs.SetActive(false);
        lung1.SetActive(false);
        lung2.SetActive(false);
        lung3.SetActive(false);
        begin = false;
        cTimes = 0;
        air.fillAmount = 0;
        Time.timeScale = 1;
        timer = 20;
    }
}
