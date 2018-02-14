using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public GameObject PickedUpKey;

	// Use this for initialization
	void Start () {
        if (PlayerData.hasKey)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && !PlayerData.hasKey)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            PlayerData.hasKey = true;
            PickedUpKey.SetActive(true);
        }
    }
}
