using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deus : MonoBehaviour {

    public GameObject player;

    private void Awake()
    {
        PlayerData.currentScene = SceneManager.GetActiveScene().name;
        ChangePosition();
    }

    private void ChangePosition()
    {
        if (PlayerData.currentScene.Equals("Station") && PlayerData.previousScene.Equals("Tunnel"))
        {
            player.transform.position = PlayerData.station1;
            return;
        }
        if (PlayerData.currentScene.Equals("Tunnel") && PlayerData.previousScene.Equals("LocalElectrique"))
        {
            player.transform.position = PlayerData.tunnel1;
            return;
        }
        return;
    }
}
