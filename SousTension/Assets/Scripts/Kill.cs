using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour {

    public AudioClip deathClip;
    public FadeManager fade;

    private AudioSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            collision.gameObject.transform.Rotate(new Vector3(45, 0, 0));
            StartCoroutine(Death());
        }
    }

    private IEnumerator Death()
    {
        source.clip = deathClip;
        source.Play();
        fade.Fade(false, 30f);
        yield return new WaitForSeconds(source.clip.length-2);
        SceneManager.LoadScene("GameOver");
    }
}
