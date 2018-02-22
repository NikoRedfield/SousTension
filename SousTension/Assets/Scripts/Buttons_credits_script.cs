using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Buttons_credits_script : MonoBehaviour {
    public Sprite TagClavier;
    public Sprite TagManette;

    private ControllerStatus controller;  //Check the used input device
    private int controllerState;

    private void Start()
    {
        controller = this.GetComponent<ControllerStatus>();
        this.GetComponent<Image>().overrideSprite = TagClavier;
        controllerState = controller.ControllerCheck();
        SwitchUI();     //Switch UI depending on the device used
    }

    // Update is called once per frame
    void Update()
    {
        controllerState = controller.ControllerCheck();
        SwitchUI();
    }

    //Check what UI to display
    private void SwitchUI()
    {
        switch (controllerState)
        {
            case 0:
                this.GetComponent<Image>().overrideSprite = TagClavier;
                break;
            case 1:
                this.GetComponent<Image>().overrideSprite = TagManette;
                break;

            default:
                Debug.Log("Error on SwitchUI");
                break;
        }
    }

}
