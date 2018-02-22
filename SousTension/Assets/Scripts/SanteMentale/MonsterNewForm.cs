using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterNewForm : MonoBehaviour {

    public AudioClip clipCrescendo;
    public AudioClip breakSFX;
    public AudioClip monsterTheme;
    public GameObject monster;

    private AudioSource source;
    private bool engaged; //Checks if the monster's feedback has been engaged
    private int requiredSM; //Required SM in order to release the monster
    private bool finalForm; //Checks if the monster has reached his final form
    private float monsterFinalSize; //The width the monster must acquire in order to be considered into his final form
    private GameObject cam;
    private int monsterInitSize;

    private bool spawnNow;


	void Start () {
        source = this.GetComponent<AudioSource>();
        requiredSM = PlayerData.maxSanteMentale * 5 / 100;
        Debug.Log("Required SM for monster: " + requiredSM);
        engaged = false;
        cam = GameObject.Find("Main Camera");
        monsterFinalSize = 1.5f;
        monsterInitSize = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (source.isPlaying)
        {
            Debug.Log("DDNKSJDHFKDSHFDSKJGFKFDHGKJ");
        }
        if (!source.isPlaying)
        {
            Debug.Log("Putain sa mère ça marche pas");
            source.Play();
        }
		if((PlayerData.santeMentale <= requiredSM && PlayerData.objective3 && !PlayerData.objective5) || spawnNow || (PlayerData.santeMentale <= requiredSM && PlayerData.generators))
        {
            if (!engaged)
            {
                ReleaseMonster();
            }
            if (!finalForm)
            {
                Evolve();
            }
        }
        else
        {
            if (engaged)
            {
                ResetFeedback();
            }
        }
	}


    public void ResetFeedback()
    {
        monster.transform.localScale = new Vector3(monsterInitSize, monster.transform.localScale.y, monster.transform.localScale.z);
        monster.SetActive(false);
        source.volume = 0;
        source.Stop();
        engaged = false;
        finalForm = false;
        if (!cam.GetComponent<CameraFollow2D>().enabled)
        {
            SwitchCamera();
        }
        
        

    }

    private void ReleaseMonster()
    {
        Debug.Log("Released");
        engaged = true;
        monster.SetActive(true);
        source.clip = clipCrescendo;
        source.Play();
        source.volume = 1;
    }

    //Growing the monster and the volume of the supensfull music
    private void Evolve()
    {
        if (ReachedFinalForm())
        {
         
                finalForm = true;
                Attack();
            

        }
        else
        {
            monster.transform.localScale = new Vector3(monster.transform.localScale.x + 0.0025f, monster.transform.localScale.y, monster.transform.localScale.z);
            source.volume = 1; ;//0.002f;
            if (!source.isPlaying)
            {
                source.Play();
            }
        }
    }

    private bool ReachedFinalForm()
    {
        return (monster.transform.localScale.x >= monsterFinalSize) ? true : false;
    }

    private void Attack()
    {
        StartCoroutine(SwitchAudio());
        

    }

    IEnumerator SwitchAudio()
    {
       // source.Stop();
       // source.clip = breakSFX;
       // source.Play();
        yield return new WaitForSeconds(0);//breakSFX.length - 2f);
        source.clip = monsterTheme;
        source.Play();
        source.loop = true;
        SwitchCamera();
    }

    private void SwitchCamera()
    {
        if (cam.GetComponent<CameraFollow2D>().enabled)
        {
            cam.GetComponent<CameraFollow2D>().enabled = false;
            cam.GetComponent<CameraScroll>().enabled = true;
        }
        else
        {
            cam.GetComponent<CameraFollow2D>().enabled = true;
            cam.GetComponent<CameraScroll>().enabled = false;
        }
    }

    public void SetSpawn(bool value)
    {
        this.spawnNow = value;
    }
}
