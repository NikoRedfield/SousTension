using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchNarrationKey : MonoBehaviour {

    //public DialogueManager dialogue;
    public Narration dialogue1;
    public Narration dialogue2;

    private Narration dialogue;

	// Use this for initialization
	void Start () {
        if (PlayerData.hasKey)
        {
            dialogue = dialogue1;
            dialogue2.transform.parent.gameObject.SetActive(false);
            dialogue.StartDialogue();
        }
        else
        {
            dialogue = dialogue2;
            dialogue1.transform.parent.gameObject.SetActive(false);
            dialogue.StartDialogue();
        }
        
	}
	

}
