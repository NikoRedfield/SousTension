using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulleD3 : MonoBehaviour {

    public GameObject Bulle;
    // Use this for initialization
    void Start () {
        StartCoroutine(ActivateThought());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator ActivateThought()
    {
        Bulle.SetActive(true);
        yield return new WaitForSeconds(5);
        Bulle.SetActive(false);
    }
}
