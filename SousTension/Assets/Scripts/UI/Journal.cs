using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour {

    private void Start()
    {
        if (PlayerData.Ejournal)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!PlayerData.Ejournal)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            PlayerData.Ejournal = true;
            PlayerData.clues = true;
            this.GetComponent<AudioSource>().Play();
        }
        
    }
}
