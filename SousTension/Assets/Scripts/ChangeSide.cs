using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSide : MonoBehaviour {

    public GameObject sideA;
    public GameObject sideB;
    public FadeManager fade;
    public int diminution = 0;

    

	// Use this for initialization
	void Start () {
        fade.Fade(false, 10f);
        sideA.SetActive(false);
        sideB.SetActive(true);
        GameObject.Find("SanteMentale").GetComponent<SanteMentale>().diminution = diminution;
	}
	

}
