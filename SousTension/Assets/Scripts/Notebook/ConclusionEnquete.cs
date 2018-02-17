using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConclusionEnquete : MonoBehaviour {

    public GameObject Pict1;
    public GameObject Pict2;
    public GameObject unknown1;
    public GameObject unknown2;
    public GameObject indice1;
    public GameObject indice2;
    public GameObject indice3;
    public GameObject indice4;
    public GameObject conclusion1;
    public GameObject conclusion2;
    public GameObject conclusionUnknown;
    public GameObject conclusionPartiel;
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
            Pict1.SetActive(true);
            indice1.SetActive(true);
        }
        if (PlayerData.Sang2)
        {
            Pict1.SetActive(true);
            indice2.SetActive(true);
        }
        if(!PlayerData.Sang1 && !PlayerData.Sang2)
        {
            unknown1.SetActive(true);
        }
        if (PlayerData.Journal1)
        {
            Pict2.SetActive(true);
            indice3.SetActive(true);
        }
        if (PlayerData.Journal2)
        {
            Pict2.SetActive(true);
            indice4.SetActive(true);
        }
        if(!PlayerData.Journal1 && !PlayerData.Journal2)
        {
            indice2.SetActive(true);
        }
        if(PlayerData.Sang1 && PlayerData.Journal1)
        {
            conclusion1.SetActive(true);
        }
        if((PlayerData.Sang1 && PlayerData.Journal2)||(PlayerData.Sang2 && PlayerData.Journal1)|| (PlayerData.Journal2 && PlayerData.Sang2))
        {
            conclusion2.SetActive(true);
        }
        if(((PlayerData.Sang1 || PlayerData.Sang2) && !PlayerData.Journal1 && !PlayerData.Journal2)||((PlayerData.Journal1 || PlayerData.Journal2) && !PlayerData.Sang1 && !PlayerData.Sang2))
        {
            conclusionPartiel.SetActive(true);
        }
        if(!PlayerData.Sang1 && !PlayerData.Sang2 && !PlayerData.Journal1 && !PlayerData.Journal2)
        {
            conclusionUnknown.SetActive(true);
        }
    }
}
