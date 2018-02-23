using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnNOW : MonoBehaviour {

    public MonsterNewForm monster;
    public GameObject Bulle;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDisable()
    {
        monster.SetSpawn(true);
        if(Bulle != null)
        {
            Debug.Log("trouvé!!!!!");
            Bulle.SetActive(true);
        }
        else
        {
            Debug.Log("Pastrouvé :'(");
        }
    }
}
