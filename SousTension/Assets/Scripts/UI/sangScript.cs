using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class sangScript : MonoBehaviour {

    public GameObject monster;
    public GameObject Bulle;
    public string text2;

    private GameObject player;
    public GameObject groupBox;
    private bool firstTime = false;
    private Vector3 wantedPos;
    private bool toLeft = false;
    private float newX;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        updateMoveBox();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && firstTime == false)
        {
            firstTime = true;
            toLeft = true;
            Debug.Log("Collision detectee");
            moveBox();
            PlayerData.Esang = true;
            PlayerData.clues = true;
            this.GetComponent<AudioSource>().Play();
            if (!monster.activeSelf)
            {
                StartCoroutine(StopPlayer());
            }
            StartCoroutine(DisplayBubble());
            
        }
    }

    private void moveBox()
    {
        wantedPos = groupBox.transform.position;
        wantedPos.x = wantedPos.x - 3;
    }

    private void updateMoveBox()
    {
        if (toLeft == true && groupBox.transform.position.x > wantedPos.x)
        {
            newX = groupBox.transform.position.x - 0.01f;
            groupBox.transform.position = new Vector3(newX, groupBox.transform.position.y, groupBox.transform.position.z);
            if (groupBox.transform.position.x <= wantedPos.x)
            {
                toLeft = false;
                wantedPos.x = wantedPos.x + 3;
            }
        }
        if (toLeft == false && groupBox.transform.position.x < wantedPos.x)
        {
            newX = groupBox.transform.position.x + 0.01f;
            groupBox.transform.position = new Vector3(newX, groupBox.transform.position.y, groupBox.transform.position.z);
        }
    }

    private IEnumerator StopPlayer()
    {
        player.GetComponent<Platformer2DUserControl>().backward = false;
        player.GetComponent<Platformer2DUserControl>().SetAuthorisation(false);
        player.GetComponent<PlatformerCharacter2D>().Move(0, false, false);
        yield return new WaitForSeconds(10);
        player.GetComponent<Platformer2DUserControl>().SetAuthorisation(true);
        
    }

    private IEnumerator DisplayBubble()
    {
        Bulle.SetActive(true);
        yield return new WaitForSeconds(6);
        Bulle.GetComponentInChildren<Text>().text = text2;
        yield return new WaitForSeconds(7);
        Bulle.SetActive(false);
    }
}