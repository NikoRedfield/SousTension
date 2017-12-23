using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSide : MonoBehaviour {

    public GameObject sideA;
    public GameObject sideB;
    public FadeManager fade;
    public int diminution = 0;
    public GameObject monstre;

   

    

	// Use this for initialization
	void Start () {
        fade.Fade(false, 10f);
        sideA.SetActive(false);
        sideB.SetActive(true);
        GameObject.Find("SanteMentale").GetComponent<SanteMentale>().diminution = diminution;
        if (monstre.activeSelf)
        {
            PlayerData.santeMentale = 180; //180
        }
        monstre.SetActive(false);
        GameObject.Find("HUD").transform.GetChild(2).GetComponent<SanteMentale>().ResetTriggers();
        GameObject.Find("Main Camera").GetComponent<CameraScroll>().enabled = false;
        GameObject.Find("Main Camera").GetComponent<CameraFollow2D>().enabled = true;
    }

    private void Update()
    {
        if(sideB.activeSelf && monstre.activeSelf)
        {
            monstre.GetComponent<MonsterMovement>().StuckToCameraRight = true;
            GameObject.Find("Main Camera").GetComponent<CameraScroll>().right = true;
            GameObject.Find("Main Camera").GetComponent<CameraScroll>().enabled = true;
            GameObject.Find("Main Camera").GetComponent<CameraScroll>().offset.y = 4;
            GameObject.Find("Main Camera").GetComponent<CameraScroll>().offset.z = -20;
            GameObject.Find("Main Camera").GetComponent<CameraFollow2D>().enabled = false;
        }
    }


}
