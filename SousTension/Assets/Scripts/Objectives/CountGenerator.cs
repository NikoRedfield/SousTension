using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountGenerator : MonoBehaviour {

    public int numberOfGenerators;

    private int counter = 0;


    public void AddGenerator()
    {
        counter++;
        if(counter == numberOfGenerators)
        {
            PlayerData.generators = true;
        }
    }
}
