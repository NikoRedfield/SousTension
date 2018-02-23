using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Sprint : MonoBehaviour {

    public GameObject player;
    public AudioClip breathStart;
    public AudioClip breathEnd;
    public int maxSprint = 1000;

    private PlatformerCharacter2D characterControl;
    private int sprintValue;
    private AudioSource source;
    private AudioSource secondSource;

	// Use this for initialization
	void Start () {
        sprintValue = maxSprint;
        characterControl = player.GetComponent<PlatformerCharacter2D>();
        source = this.GetComponent<AudioSource>();
        secondSource = this.transform.GetChild(0).GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (characterControl.IsMoving() && characterControl.IsSprinting())
        {
            sprintValue--;
            if (!source.isPlaying)
            {
                source.clip = breathStart;
               // source.loop = true;
                source.Play();
            }
            if(sprintValue <= 0)
            {
             
                characterControl.SetSprint(false);
                sprintValue = 0;
                if(breathEnd != null)
                {
                    source.Stop();
                    if (!secondSource.isPlaying)
                    {
                        secondSource.PlayOneShot(breathEnd);
                    }
                    
                  
                   
                }
                else
                {
                    source.Stop();
                }
               
            }
           // Debug.Log("Sprint: " + sprintValue);
        }
        else
        {
            sprintValue++;
            if (source.isPlaying)
            {
                source.Stop();
            }
            if(sprintValue > maxSprint)
            {
                sprintValue = maxSprint;
            }
          //  Debug.Log("Sprint: " + sprintValue);
        }
	}


}
