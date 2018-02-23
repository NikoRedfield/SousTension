using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class NavigateEvts : MonoBehaviour {

    public GameObject fichesPerso;
    public GameObject fichesEnquete;
    public AudioClip clip;

    private float h;
    private float h2;
    private int fichesCount;
    private int currentIndex = 0;
   // private GameObject fiches;
  //  private GameObject story;
    private GameObject codex;
    private int delay = 8;
    private int currentTime = 8;
    private bool check = false;
    private int waitForSubmit = 0;
    private GameObject controls;
    private AudioSource source;

    // Use this for initialization
    void Start () {
       fichesCount = this.transform.childCount;
       // story = GameObject.Find("BookUI").transform.GetChild(1).gameObject;
        codex = GameObject.Find("BookUI").transform.GetChild(1).gameObject;
        controls = GameObject.Find("BookUI").transform.GetChild(0).gameObject;
        source = this.GetComponentInParent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
       
        if (!codex.activeSelf && !fichesEnquete.activeSelf && !fichesPerso.activeSelf)
        {
            h = CrossPlatformInputManager.GetAxis("Arrows");
            h2 = CrossPlatformInputManager.GetAxis("DpadH");
            if (Input.GetKeyDown(KeyCode.RightArrow) && currentIndex < fichesCount - 1)
            {
                currentIndex++;
                DisplayData(currentIndex, currentIndex - 1);
                source.clip = clip;
                source.Play();
            }
            if (h > 0 || h2 > 0)
            {
                currentTime++;
                if (currentIndex < fichesCount -1 && currentTime > delay )
                {
                    currentTime = 0;
                    currentIndex++;
                    DisplayData(currentIndex, currentIndex - 1);
                    source.clip = clip;
                    source.Play();
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && currentIndex >0)
            {
                currentIndex--;
                DisplayData(currentIndex, currentIndex + 1);
                source.clip = clip;
                source.Play();
            }
            if ( h < -0.8 || h2 < -0.8) {
                currentTime++;
                if (currentIndex > 0 && currentTime > delay)
                {
                    currentTime = 0;
                    currentIndex--;
                    DisplayData(currentIndex, currentIndex + 1);
                    source.clip = clip;
                    source.Play();
                }
            }
            if (CrossPlatformInputManager.GetButtonDown("SelectBook"))
            {
                if (waitForSubmit > 60)
                {
                    controls.SetActive(true);
                    this.transform.GetChild(currentIndex).gameObject.SetActive(false);
                    currentIndex = 0;
                    codex.SetActive(true);
                   /* Color postIt = GameObject.Find("StoryName").GetComponent<Image>().color;
                    postIt.a = 0f;//0.5f;
                    GameObject.Find("StoryName").GetComponent<Image>().color = postIt;
                    Color postIt2 = GameObject.Find("CodexName").GetComponent<Image>().color;
                    postIt2.a = 0.4f;
                    GameObject.Find("CodexName").GetComponent<Image>().color = postIt2;*/
                    codex.transform.GetChild(0).GetComponent<Button>().Select();
                    codex.transform.GetChild(0).GetComponent<Button>().OnSelect(null);
                    waitForSubmit = 0;
                    source.clip = clip;
                    source.Play();
                    this.gameObject.SetActive(false);
                }
            }
            waitForSubmit++;
        }
	}

    //Display fiches[i] and disable fiches[j]
    void DisplayData(int i, int j)
    {
       this.transform.GetChild(i).gameObject.SetActive(true);
        this.transform.GetChild(j).gameObject.SetActive(false);
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
