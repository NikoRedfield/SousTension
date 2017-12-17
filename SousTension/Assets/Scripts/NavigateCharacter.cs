using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class NavigateCharacter : MonoBehaviour {


    private float h;
    private int fichesCount;
    private int currentIndex = 0;
    private GameObject fiches;
    private GameObject story;
    private GameObject codex;
    private int delay = 8;
    private int currentTime = 8;
    private bool check = false;
    private int waitForSubmit = 0;

	// Use this for initialization
	void Start () {
        fiches = GameObject.Find("FichesPersonnage");
        fichesCount = fiches.transform.childCount;
        story = GameObject.Find("BookUI").transform.GetChild(0).gameObject;
        codex = GameObject.Find("BookUI").transform.GetChild(1).gameObject;
    
    }
	
	// Update is called once per frame
	void Update () {
       
        if (!story.activeSelf && !codex.activeSelf)
        {
            h = CrossPlatformInputManager.GetAxis("Arrows");
            if (Input.GetKeyDown(KeyCode.RightArrow) && currentIndex < fichesCount - 1)
            {
                currentIndex++;
                DisplayData(currentIndex, currentIndex - 1);
            }
            if (h > 0)
            {
                currentTime++;
                if (currentIndex < fichesCount -1 && currentTime > delay )
                {
                    currentTime = 0;
                    currentIndex++;
                    DisplayData(currentIndex, currentIndex - 1);
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && currentIndex >0)
            {
                currentIndex--;
                DisplayData(currentIndex, currentIndex + 1);
            }
            if ( h < -0.8 ) {
                currentTime++;
                if (currentIndex > 0 && currentTime > delay)
                {
                    currentTime = 0;
                    currentIndex--;
                    DisplayData(currentIndex, currentIndex + 1);
                }
            }
            if (CrossPlatformInputManager.GetButtonDown("Submit"))
            {
                if (waitForSubmit > 60)
                {

                    fiches.transform.GetChild(currentIndex).gameObject.SetActive(false);
                    currentIndex = 0;
                    codex.SetActive(true);
                    Color postIt = GameObject.Find("StoryName").GetComponent<Image>().color;
                    postIt.a = 0.5f;
                    GameObject.Find("StoryName").GetComponent<Image>().color = postIt;
                    Color postIt2 = GameObject.Find("CodexName").GetComponent<Image>().color;
                    postIt2.a = 1f;
                    GameObject.Find("CodexName").GetComponent<Image>().color = postIt2;
                    codex.transform.GetChild(0).GetComponent<Button>().Select();
                    codex.transform.GetChild(0).GetComponent<Button>().OnSelect(null);
                    waitForSubmit = 0;
                }
            }
            waitForSubmit++;
        }
	}

    //Display fiches[i] and disable fiches[j]
    void DisplayData(int i, int j)
    {
        fiches.transform.GetChild(i).gameObject.SetActive(true);
        fiches.transform.GetChild(j).gameObject.SetActive(false);
    }

    bool CheckListen()
    {
        if (this.transform.GetChild(0).gameObject.activeSelf)
        {
            return true;
            Debug.Log("Ici");
        }

        else
        {

            return false;
        }
        
    }
}
