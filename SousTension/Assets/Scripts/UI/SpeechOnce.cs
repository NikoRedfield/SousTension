using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpeechOnce : MonoBehaviour {


    public float delay = 3f;


    //Disables the gameObject after the stated delay
    public IEnumerator Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Station":
                if (!PlayerData.stationOnce)
                {
                    PlayerData.stationOnce = true;
                    yield return new WaitForSeconds(delay);
                    
                    gameObject.SetActive(false);
                    break;
                }
                else
                {
                    gameObject.SetActive(false);
                    break;
                }
            case "Tunnel":
                if (!PlayerData.tunnelOnce)
                {
                    PlayerData.tunnelOnce = true;
                    yield return new WaitForSeconds(delay);
                    
                    gameObject.SetActive(false);
                    break;
                }
                else
                {
                    gameObject.SetActive(false);
                    break;
                }
            case "LocalElectrique":
                if (!PlayerData.localOnce)
                {
                    PlayerData.localOnce = true;
                    yield return new WaitForSeconds(delay);
                   
                    gameObject.SetActive(false);
                    break;
                }
                else
                {
                    gameObject.SetActive(false);
                    break;
                }
            default:
                gameObject.SetActive(false);
                break;
        }


    }


}
