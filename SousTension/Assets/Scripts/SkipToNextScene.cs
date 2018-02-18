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
            if (NextScene.Equals("Bonus"))
            {
                if (PlayerData.santeMentale >= PlayerData.maxSanteMentale * 0.5)
                {
                    SceneManager.LoadScene(NextScene);
                    return;
                }
                else
                {
                    NextScene = "Conclusion";
                    SceneManager.LoadScene(NextScene);
                    return;
                }
            }
            SceneManager.LoadScene(NextScene);
        }
	}
}
