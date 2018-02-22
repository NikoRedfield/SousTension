using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ec_script : MonoBehaviour {

    public Sprite[] ec;
    public string _nextScene;

    private int currentIndex = 0;
    private int pastIndex = 0;
    private int delay;
    private bool ok = true;
    private int maxDelay = 28;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        CheckCancel();
        if (ok)
        {
            CheckInput();
            delay = 0;
        }
        else
        {
            delay++;
            if(delay > maxDelay)
            {
                ok = true;
            }
        }

    }

   void CheckInput()
    {
        if(Input.GetAxis("Horizontal") > 0 || Input.GetAxis("DpadH") > 0)
        {
            currentIndex++;
            if (currentIndex == ec.Length)
            {
                currentIndex = 0;
            }
            this.GetComponent<Image>().sprite = ec[currentIndex];
            ok = false;
        }
        if (Input.GetAxis("Horizontal") < 0 || Input.GetAxis("DpadH") < 0)
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = ec.Length - 1;
            }
            this.GetComponent<Image>().sprite = ec[currentIndex];
            ok = false;
        }
    }

    void CheckCancel()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene(_nextScene);
        }
    }
}
    

