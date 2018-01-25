using System.Collections;
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
       player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().SetAuthorisation(false);
        yield return new WaitForSecondsRealtime(0.5f);
        player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().SetAuthorisation(true);
    }
    


    void CheckSanteMentale()
    {
        if (PlayerData.santeMentale < 180)
        {
            frequence = PlayerData.santeMentale + 90;
        }
        else
        {
            frequence = 0;
        }
    }
}
