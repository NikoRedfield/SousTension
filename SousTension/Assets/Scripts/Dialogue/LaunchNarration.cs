using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchNarration : MonoBehaviour {

    //public DialogueManager dialogue;
    public Narration dialogue;

	// Use this for initialization
	void Start () {
        dialogue.StartDialogue();
	}
	

}
