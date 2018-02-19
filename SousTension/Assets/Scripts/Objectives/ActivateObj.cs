using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObj : MonoBehaviour {

    public int objectiveToActivate;

	// Use this for initialization
	void Start () {
        ActiveObj();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ActiveObj()
    {
        switch (objectiveToActivate)
        {
            case 3:
                PlayerData.objective3 = true;
                break;
            case 5:
                PlayerData.objective5 = true;
                break;
            default:
                break;
        }
    }
}
