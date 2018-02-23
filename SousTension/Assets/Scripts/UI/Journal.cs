using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour {

    public GameObject Bulle;

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
            StartCoroutine(ActivateThought());
        }
        
    }

    private IEnumerator ActivateThought()
    {
        Bulle.SetActive(true);
        yield return new WaitForSeconds(6);
        Bulle.SetActive(false);
    }
}
