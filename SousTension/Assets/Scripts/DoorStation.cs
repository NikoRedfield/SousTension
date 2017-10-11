using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorStation : MonoBehaviour {

    public string _nextLevel = "";
    public FadeManager fade;
    public float _delay = 1f;

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
        if(canExit & Input.GetKeyDown("e"))
        {
            fade.Fade(false, 10f);
            StartCoroutine(FadeThenLoad()); 
        }
    }

    private IEnumerator FadeThenLoad()
    {
        yield return new WaitForSeconds(_delay);
        SceneManager.LoadScene(_nextLevel);
    }

}
