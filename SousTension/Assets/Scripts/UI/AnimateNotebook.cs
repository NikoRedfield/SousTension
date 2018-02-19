using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateNotebook : MonoBehaviour {

    public Sprite[] NotebookFlash;

    private int spriteIndex;
    private bool started = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerData.clues && !started)
        {
            InvokeRepeating("Flash", 0, 0.2f);
            started = true;
        }
        if(!PlayerData.clues)
        {
            CancelInvoke();
            this.GetComponent<Image>().sprite = NotebookFlash[0];
            started = false;
        }
	}

    void Flash()
    {
        this.GetComponent<Image>().sprite = NotebookFlash[spriteIndex];
        spriteIndex++;
        if (spriteIndex > 2)
        {
            spriteIndex = 0;
        }
    }
}
