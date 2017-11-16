using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Pause : MonoBehaviour {

    public GameObject menuToDisplay;    //UI to display for the pause menu


    private bool isActive = false;  //Checks if the pause is already active
    private string mainMenuScene = "Menu";
    private GameObject player;
    

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }


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

        if (CrossPlatformInputManager.GetButtonDown("Start"))   //Enable or Disable pause
        {
            ResumeGame();
        }

    }

    //Get back to the game
    public void ResumeGame()
    {
        isActive = !isActive;
        player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().SetAuthorisation(!isActive);
    }

    //Load the main menu scene
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    //Exit the application
    public void QuitGame()
    {
        Application.Quit();
    }
}
