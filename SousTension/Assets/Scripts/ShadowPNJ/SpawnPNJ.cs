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
        InvokeRepeating("SpawnShadows", 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
        nbPNJ = GameObject.FindGameObjectsWithTag("PNJShadow").Length;
        if(nbPNJ > maxPNJ)
        {
            CancelInvoke();
            stop = true;
        }
        if (nbPNJ < maxPNJ && stop)
        {
            InvokeRepeating("SpawnShadows", 0, 1);
            stop = false;
        }
        
	}

    void SpawnShadows()
    {
        int randSpawn = Random.Range(0, 2);
        if(randSpawn < 1)
        {
            Vector3 spawnPos = new Vector3(min, -3f, 0);
            Quaternion spawnRotation = Quaternion.Euler(0, 0, 0);
            GameObject pnj = Instantiate(shadow, spawnPos, spawnRotation);
            pnj.GetComponent<MoveShadow>().SetLeft(false);
        }
        else
        {
            Vector3 spawnPos = new Vector3(max, -3f, 0);
            Quaternion spawnRotation = Quaternion.Euler(0, 0, 0);
            GameObject pnj = Instantiate(shadow, spawnPos, spawnRotation);
            pnj.GetComponent<MoveShadow>().SetLeft(true);
        }
       
    }
}
