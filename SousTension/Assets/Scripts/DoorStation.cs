using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorStation : MonoBehaviour {

    public string _nextLevel = "";
    public FadeManager fade;
    public float _delay = 1f;
    public GameObject controllerButton;

    private bool canExit = false;

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
                fade.Fade(false, 10f);
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
        yield return new WaitForSeconds(_delay);
        SceneManager.LoadScene(_nextLevel);
    }

}
