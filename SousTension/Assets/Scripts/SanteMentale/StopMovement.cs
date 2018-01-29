﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovement : MonoBehaviour {

    private int frequence;
    private int innerDelay;
    private int delay;
    private GameObject player;

    // Use this for initialization
    void Start () {
        frequence = 0;
        innerDelay = 0;
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        CheckSanteMentale();
        if (frequence != 0)
        {
            if (innerDelay >= frequence)
            {
                innerDelay = 0;
                StartCoroutine(StopPlayer());
               // StopPlayer();
            }
            innerDelay++;
        }
    }
    
    IEnumerator StopPlayer()
    {
        if (player.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().IsFaceRight())
        {
            player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().backSpeed = -1;
        }
        else
        {
            player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().backSpeed = 1;
        }
            player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().SetAuthorisation(false);
        player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().backward = true;
        yield return new WaitForSecondsRealtime(2);
        player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().SetAuthorisation(true);
        Input.ResetInputAxes();

    }
    


    void CheckSanteMentale()
    {
        if (PlayerData.santeMentale < 180)
        {
            frequence = PlayerData.santeMentale * 10;
        }
        else
        {
            frequence = 0;
        }
    }
}
