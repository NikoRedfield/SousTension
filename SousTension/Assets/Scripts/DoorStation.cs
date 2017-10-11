using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorStation : MonoBehaviour {

    public string _nextLevel = "";

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
            SceneManager.LoadScene(_nextLevel);
        }
    }

}
