using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayUIScene : MonoBehaviour {

    private ControllerStatus controller;
    private GameObject keyboardControlsUI;
    private GameObject gamepadControlsUI;

    // Use this for initialization
    void Start () {
        controller = GameObject.Find("Manager").GetComponent<ControllerStatus>();
        keyboardControlsUI = GameObject.Find("Controls").transform.Find("Keyboard").gameObject;
        gamepadControlsUI = GameObject.Find("Controls").transform.Find("Controller").gameObject;
        switch (controller.ControllerCheck())
        {
            case 0:
                keyboardControlsUI.SetActive(true);
                break;
            case 1:
                gamepadControlsUI.SetActive(true);
                break;
            default:
                Debug.Log("Error on controls display UI ! ");
                break;
        }
    }
	

}
