using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnNOW : MonoBehaviour {

    public MonsterNewForm monster;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDisable()
    {
        monster.SetSpawn(true);
    }
}
