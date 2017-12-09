using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceNotebook : MonoBehaviour {

    public GameObject textArea;
    public RectTransform panel;
    private GameObject currentTextArea;

    private Text mtext;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void answer()
    {
        currentTextArea = (GameObject)Instantiate(textArea);
        currentTextArea.transform.SetParent(panel);
        mtext = currentTextArea.GetComponent<Text>();
        mtext.text = "mo";
    }
}
