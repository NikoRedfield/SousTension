using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Pause : MonoBehaviour {

    public GameObject menuToDisplay;


    private bool isActive = false;
    private string mainMenuScene = "Menu";


    // Update is called once per frame
    void Update()
    {

        if (isActive)
        {
            menuToDisplay.SetActive(true);
            //Cursor.visible = true;
          //  Cursor.lockState = CursorLockMode.Confined;
            //Time.timeScale = 0;

        }

        else
        {

            menuToDisplay.SetActive(false);
          //  Cursor.visible = false;
           // Cursor.lockState = CursorLockMode.None;
            //Time.timeScale = 1;
        }

        if (CrossPlatformInputManager.GetButtonDown("Start"))
        {
            ResumeGame();
        }

    }

    public void ResumeGame()
    {
        isActive = !isActive;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
