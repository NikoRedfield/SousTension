using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchDisplayUI : MonoBehaviour {

    public Sprite UIcontroller;
    public Sprite UIkeyboard;

    private ControllerStatus controller;  //Check the used input device
    private Image displayedUI;
    private int controllerState;

    // Use this for initialization
    void Awake () {
        displayedUI = this.GetComponent<Image>();
        controller = this.GetComponent<ControllerStatus>();
        displayedUI.sprite = UIcontroller;
        controllerState = controller.ControllerCheck();
        SwitchUI();     //Switch UI depending on the device used
    }
	/*
	// Update is called once per frame
	void Update () {
        controllerState = controller.ControllerCheck();
        SwitchUI();     //Switch UI depending on the device used
    }*/

    //Check what UI to display
    private void SwitchUI()
    {
        switch (controllerState)
        {
            case 0:
                displayedUI.sprite = UIkeyboard;
                break;
            case 1:
                displayedUI.sprite = UIcontroller;
                break;

            default:
                Debug.Log("Error on SwitchUI");
                break;
        }
    }
}
