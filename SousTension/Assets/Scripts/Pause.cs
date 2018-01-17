using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    public GameObject menuToDisplay;    //UI to display for the pause menu
    public GameObject optionPanel;

    private bool isActive = false;  //Checks if the pause is already active
    private string mainMenuScene = "Menu";
    private GameObject player;
    private bool optionScreen = false;
    

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
        }
        else
        {
            menuToDisplay.SetActive(false);
        }

            if (CrossPlatformInputManager.GetButtonDown("Start"))   //Enable or Disable pause
        {
            if (optionScreen)
            {
                SwitchPanel();
            }
            else
            {
                ResumeGame();
            }
        }

    }

    //Get back to the game
    public void ResumeGame()
    {
        isActive = !isActive;
      
        player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().SetAuthorisation(!isActive);
      
        
        if (isActive)
        {
            
            menuToDisplay.SetActive(true);
            menuToDisplay.transform.GetChild(2).GetComponent<Button>().Select();
            menuToDisplay.transform.GetChild(2).GetComponent<Button>().OnSelect(null);
            Time.timeScale = 0;
            //Cursor.visible = true;
            //  Cursor.lockState = CursorLockMode.Confined;
            //Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            menuToDisplay.SetActive(false);
            //  Cursor.visible = false;
            // Cursor.lockState = CursorLockMode.None;
            //Time.timeScale = 1;
        }
    }

    //Load the main menu scene
    public void MainMenu()
    {
        PlayerData.santeMentale = 300;
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenuScene);
    }

    //Exit the application
    public void QuitGame()
    {
        Application.Quit();
    }

    public void OptionScreen()
    {
        optionScreen = true;
        menuToDisplay.gameObject.SetActive(false);
        optionPanel.SetActive(true);
        optionPanel.transform.GetChild(2).GetComponent<Slider>().Select();
    }

    private void SwitchPanel()
    {
        if (optionPanel.activeSelf)
        {
            menuToDisplay.SetActive(true);
            optionPanel.SetActive(false);
            optionScreen = false;
            menuToDisplay.transform.GetChild(2).GetComponent<Button>().Select();
            menuToDisplay.transform.GetChild(2).GetComponent<Button>().OnSelect(null);
        }
        return;
    }
}
