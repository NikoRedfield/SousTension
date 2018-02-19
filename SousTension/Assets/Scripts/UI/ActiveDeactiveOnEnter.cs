using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveDeactiveOnEnter : MonoBehaviour {

    public GameObject bulleToDisplay;
    public string[] texts;

    private int index;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            bulleToDisplay.SetActive(true);
            index = Random.Range(0, texts.Length);
            bulleToDisplay.GetComponentInChildren<Text>().text = texts[index];
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            bulleToDisplay.SetActive(false);
        }
    }
}
