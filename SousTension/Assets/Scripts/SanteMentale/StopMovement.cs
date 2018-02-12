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
        yield return new WaitForSecondsRealtime(0.5f);
        player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().SetAuthorisation(true);
        Input.ResetInputAxes();
        player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().backward = false;

    }
    


    void CheckSanteMentale()
    {
        if (PlayerData.santeMentale < PlayerData.maxSanteMentale * 0.75 && PlayerData.santeMentale > PlayerData.maxSanteMentale * 0.65)
        {
            Debug.Log("movement " + frequence);
            frequence = 600;
            return;
            //frequence = PlayerData.santeMentale * 7;
        }
        else
        {
            if (PlayerData.santeMentale < PlayerData.maxSanteMentale * 0.64 && PlayerData.santeMentale > PlayerData.maxSanteMentale * 0.55)
            {
                //frequence = PlayerData.santeMentale * 40;
                frequence = 300;
                return;
            }

            else
            {
                if (PlayerData.santeMentale < PlayerData.maxSanteMentale * 0.54 && PlayerData.santeMentale > PlayerData.maxSanteMentale * 0.51)
                {
                    frequence = 180;
                    return;
                }
                else
                {
                    frequence = 0;
                    return;
                }
            }
        }
       
     
    }
}
