using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillLocal : MonoBehaviour {

    public AudioClip deathClip;  //Death Sound

    private FadeManager fade;
    private AudioSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        fade = GameObject.Find("FadeManager").GetComponent<FadeManager>();
	}

    //Kills the player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")    //If the player is in reach 
        {
            Debug.Log("Hit");
            collision.gameObject.transform.Rotate(new Vector3(45, 0, 0));
            if(PlayerData.caughtByMonster >= 1)
            {
                StartCoroutine(Death());
            }
            else
            {
                StartCoroutine(BackStation());
                PlayerData.caughtOnce = true;
            }
        }
    }


    //Loads GameOver Scene
    private IEnumerator Death()
    {
        source.clip = deathClip;
        source.Play();
        fade.Fade(false, 30f);
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene("GameOver");
    }

    //Loads GameOver Scene
    private IEnumerator BackStation()
    {
        source.clip = deathClip;
        source.Play();
        fade.Fade(false, 30f);
        yield return new WaitForSeconds(0);
        PlayerData.santeMentale = 1000;
        PlayerData.caughtByMonster++;
        PlayerData.spawnAfterCaughtOnce = true;
        SceneManager.LoadScene("Station");
    }
}
