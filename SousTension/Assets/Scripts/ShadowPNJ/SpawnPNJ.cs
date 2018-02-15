using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPNJ : MonoBehaviour {

    public GameObject shadow;
    public int min;
    public int max;
    public int maxPNJ;

    private int nbPNJ;
    private bool stop = false;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnShadows", 1, 4);
	}
	
	// Update is called once per frame
	void Update () {
        nbPNJ = GameObject.FindGameObjectsWithTag("PNJShadow").Length;
        if(nbPNJ > maxPNJ)
        {
            CancelInvoke();
            stop = true;
        }
        if (nbPNJ < maxPNJ / 2 && stop)
        {
            InvokeRepeating("SpawnShadows", 1, 4);
            stop = false;
        }
        
	}

    void SpawnShadows()
    {
        Vector3 spawnPos = new Vector3(Random.Range(min, max), -3f, 0);
        Quaternion spawnRotation = Quaternion.Euler(0, 0, 0);
        Instantiate(shadow, spawnPos,spawnRotation);
    }
}
