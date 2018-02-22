using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlockEntrance : MonoBehaviour {

    public GameObject bulleToDisplay;
    public GameObject secondBulle;
    public string[] texts;
    public GameObject EnterUI;
    public bool door = false;

    private int index;
    private bool authorise = false;
    private string sceneToLoad;
    private bool authorise2;


	
	// Update is called once per frame
	void Update () {
        HashAuthorisation();
        if(authorise && Input.GetAxis("Vertical") > 0 &&!door && authorise2)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !authorise)
        {
            if(secondBulle == null || !secondBulle.activeSelf)
            {
                bulleToDisplay.SetActive(true);
                index = Random.Range(0, texts.Length);
                bulleToDisplay.GetComponentInChildren<Text>().text = texts[index];
            }
        }
        if(collision.tag == "Player" && authorise)
        {
            EnterUI.SetActive(true);
        }
        authorise2 = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            bulleToDisplay.SetActive(false);
            EnterUI.SetActive(false);
            
        }
        authorise2 = false;
    }

   private void HashAuthorisation()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Station":
                if(PlayerData.objective3 && !PlayerData.generators && !PlayerData.objective5)
                {
                    authorise = true;
                    sceneToLoad = "Dialogue4";
                    break;
                }
                if(PlayerData.objective5 && PlayerData.generators)
                {
                    authorise = true;
                    sceneToLoad = "Dialogue7";
                    break;
                }
                else
                {
                    authorise = false;
                    break;
                }

            case "Tunnel":
                if (PlayerData.objective3 && PlayerData.objective5 && !PlayerData.generators)
                {
                    authorise = true;
                    sceneToLoad = "LocalElectrique";
                    break;
                }
                else
                {
                    authorise = false;
                    break;
                }

            case "LocalElectrique":
                if (PlayerData.generators)
                {
                    authorise = true;
                    sceneToLoad = "Tunnel";
                    break;
                }
                else
                {
                    authorise = false;
                    break;
                }
            default:
                authorise = false;
                break;
        }
    }
}
