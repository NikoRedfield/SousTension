using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorStation : MonoBehaviour {

    public string _nextLevel = "";
    public FadeManager fade;
    public float _delay = 1f;
    public GameObject controllerButton;
    public AudioClip clip;

    private bool canExit = false;
    private AudioSource source;

    private void Start()
    {
        source = this.GetComponent<AudioSource>();
        source.clip = clip;
        //DontDestroyOnLoad(fade.gameObject);
    }

    private  void OnTriggerEnter2D(Collider2D col)
    {
        canExit = true;
    }

   private  void OnTriggerExit2D(Collider2D col)
    {
        canExit = false;
    }

    private void Update()
    {
        if(canExit)
        {
            controllerButton.SetActive(true);

            if (Input.GetKeyDown("e") || Input.GetButtonDown("Submit"))
            {
                
                StartCoroutine(FadeThenLoad());
            }
        }
        else
        {
            controllerButton.SetActive(false);
        }
    }

    private IEnumerator FadeThenLoad()
    {
        source.Play();
        fade.gameObject.SetActive(true);
        fade.Fade(false, 30f);
        yield return new WaitForSeconds(clip.length-1f);
        SceneManager.LoadScene(_nextLevel);
    }

}
