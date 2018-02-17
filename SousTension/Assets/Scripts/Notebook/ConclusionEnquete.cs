using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConclusionEnquete : MonoBehaviour {

    public GameObject indice1;
    public GameObject indice2;
    public GameObject indice3;
    public GameObject indice4;
    public GameObject conclusion1;
    public GameObject conclusion2;
    public string NextScene;

    // Use this for initialization
    void Start () {
        ChooseText();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Submit"))
        {
            SceneManager.LoadScene(NextScene);
        }
	}

    void ChooseText()
    {
        if (PlayerData.Sang1)
        {
            indice1.SetActive(true);
        }
        if (PlayerData.Sang2)
        {
            indice2.SetActive(true);
        }
        if (PlayerData.Journal1)
        {
            indice3.SetActive(true);
        }
        if (PlayerData.Journal2)
        {
            indice4.SetActive(true);
        }
        if(PlayerData.Sang1 && PlayerData.Journal1)
        {
            conclusion1.SetActive(true);
        }
        if(PlayerData.Journal2 && PlayerData.Sang2)
        {
            conclusion2.SetActive(true);
        }
    }
}
