using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipToNextScene : MonoBehaviour {

    public string NextScene;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("s"))
        {
            StopAllCoroutines();
            SceneManager.LoadScene(NextScene);
        }
	}
}
