using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnAfterLocal : MonoBehaviour {

    public MonsterNewForm monster;
 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerData.generators && !PlayerData.spawnedAfterLocal)
        {
            monster.SetSpawn(true);
            PlayerData.spawnedAfterLocal = true;
        }
	}


}
