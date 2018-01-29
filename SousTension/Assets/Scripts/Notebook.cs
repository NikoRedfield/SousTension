using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Notebook : MonoBehaviour {

    private GameObject story;
    private GameObject codex;
    private Image storyName;
    private Image codexName;
    private int delay = 0;
    private GameObject FadeL;
    private GameObject FadeR;
    private GameObject FadeL2;
    private GameObject FadeR2;
    private GameObject controls;
    private ControllerStatus controller;
    private int controllerState;

    // Use this for initialization
    void Start () {
        storyName = GameObject.Find("StoryName").GetComponent<Image>();
        codexName = GameObject.Find("CodexName").GetComponent<Image>();
        story = this.transform.GetChild(1).gameObject;
        codex = this.transform.GetChild(2).gameObject;
        FadeL = codex.transform.GetChild(4).gameObject;
        FadeR = codex.transform.GetChild(3).gameObject;
        FadeR2 = story.transform.GetChild(1).gameObject;
        FadeL2 = story.transform.GetChild(2).gameObject;
        codex.transform.GetChild(0).GetComponent<Button>().interactable = false;
        codex.transform.GetChild(2).GetComponent<Button>().interactable = false;
        EventSystem.current.SetSelectedGameObject(null);
        controls = this.transform.GetChild(0).gameObject;
        controller = controls.GetComponent<ControllerStatus>();
        controllerState = controller.ControllerCheck();
        SwitchUI();     //Switch UI depending on the device used
    }
	
	// Update is called once per frame
	void Update () {
        controllerState = controller.ControllerCheck();
        SwitchUI();
        if (CrossPlatformInputManager.GetAxisRaw("Vertical") != 0 && CheckListen())
        {
            if(delay > 6)
            {
                if ((FadeR.activeSelf && codex.activeSelf)  || (FadeR2.activeSelf && story.activeSelf))
                {
                    SwitchSection();
                    delay = 0;
                }
                
            }
            else
            {
                delay++;
            }
        }
        if (CrossPlatformInputManager.GetAxisRaw("Horizontal") != 0 && CheckListen())
        {
            if (delay > 6)
            {
                SwitchSectionHorizontale();
                delay = 0;
            }
            else
            {
                delay++;
            }
        }




    }

    void SwitchSection()
    {
        if (story.gameObject.activeSelf)
        {
            story.gameObject.SetActive(false);
            codex.gameObject.SetActive(true);
            codex.transform.GetChild(0).GetComponent<Button>().Select();
            codex.transform.GetChild(0).GetComponent<Button>().OnSelect(null);
            Color postIt = storyName.color;
            postIt.a = 0f;
            storyName.color = postIt;
            Color postIt2 = codexName.color;
            postIt2.a = 0.4f;
            codexName.color = postIt2;
        }
        else
        {
            story.gameObject.SetActive(true);
            codex.gameObject.SetActive(false);
            Color postIt = codexName.color;
            postIt.a = 0f;
            codexName.color = postIt;
            Color postIt2 = storyName.color;
            postIt2.a = 0.4f;
           storyName.color = postIt2;
        }
    }

    private void SwitchSectionHorizontale()
    {
        if (codex.activeSelf)
        {
            if (FadeL.activeSelf)
            {
                FadeR.SetActive(true);
                FadeL.SetActive(false);
                codex.transform.GetChild(0).GetComponent<Button>().interactable = false;
                codex.transform.GetChild(2).GetComponent<Button>().interactable = false;
                EventSystem.current.SetSelectedGameObject(null);
            }
            else
            {
                FadeR.SetActive(false);
                FadeL.SetActive(true);
                codex.transform.GetChild(0).GetComponent<Button>().interactable = true;
                codex.transform.GetChild(2).GetComponent<Button>().interactable = true;
                codex.transform.GetChild(0).GetComponent<Button>().Select();
                codex.transform.GetChild(0).GetComponent<Button>().OnSelect(null);
            }
        }
        else
        {
            if (FadeL2.activeSelf)
            {
                FadeR2.SetActive(true);
                FadeL2.SetActive(false);
            }
            else
            {
                FadeR2.SetActive(false);
                FadeL2.SetActive(true);
            }
        }
}


    public void DisplayCharacters()
    {
        GameObject.Find("FichesPersonnage").transform.GetChild(0).gameObject.SetActive(true);
        controls.SetActive(false);

        if (story.gameObject.activeSelf)
        {
            story.gameObject.SetActive(false);
        }
        else
        {
            codex.gameObject.SetActive(false);
        }
    }

    bool CheckListen()
    {
        if (!story.gameObject.activeSelf && !codex.gameObject.activeSelf)
        {
            return false;
        }
        return true; 
    }


    //Check what UI to display
    private void SwitchUI()
    {
        switch (controllerState)
        {
            case 0:
                controls.transform.GetChild(8).gameObject.SetActive(true);
                controls.transform.GetChild(7).gameObject.SetActive(false);
                break;
            case 1:
                controls.transform.GetChild(8).gameObject.SetActive(false);
                controls.transform.GetChild(7).gameObject.SetActive(true);
                break;

            default:
                Debug.Log("Error on SwitchUI");
                break;
        }
    }



}
