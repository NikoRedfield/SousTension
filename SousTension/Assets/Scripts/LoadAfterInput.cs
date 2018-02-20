using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadAfterInput : MonoBehaviour
{

    public string _nextScene = "";

    public string input = "Submit";


    //Load the given scene after the stated input has been made
    private void Update()
    {
        if (Input.GetButton(input))
        {
            SceneManager.LoadScene(_nextScene);
        }
        
    }
}
