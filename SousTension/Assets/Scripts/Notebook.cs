using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Notebook : MonoBehaviour {

    private GameObject story;
    private GameObject codex;
    private Image storyName;
    private Image codexName;

	// Use this for initialization
	void Start () {
        storyName = GameObject.Find("StoryName").GetComponent<Image>();
        codexName = GameObject.Find("CodexName").GetComponent<Image>();
        story = this.transform.GetChild(0).gameObject;
        codex = this.transform.GetChild(1).gameObject;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (CrossPlatformInputManager.GetButtonDown("Jump") && CheckListen())
        {
            SwitchSection();
        }


	}

    void SwitchSection()
    {
        if (story.gameObject.activeSelf)
        {
            story.gameObject.SetActive(false);
            codex.gameObject.SetActive(true);
            codex.transform.GetChild(0).GetComponent<Button>().Select();
            Color postIt = storyName.color;
            postIt.a = 0.5f;
            storyName.color = postIt;
            Color postIt2 = codexName.color;
            postIt2.a = 1;
            codexName.color = postIt2;
        }
        else
        {
            story.gameObject.SetActive(true);
            codex.gameObject.SetActive(false);
            Color postIt = codexName.color;
            postIt.a = 0.5f;
            codexName.color = postIt;
            Color postIt2 = storyName.color;
            postIt2.a = 1;
            storyName.color = postIt2;
        }
    }

    public void DisplayCharacters()
    {
        GameObject.Find("FichesPersonnage").transform.GetChild(0).gameObject.SetActive(true);
        
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


}
