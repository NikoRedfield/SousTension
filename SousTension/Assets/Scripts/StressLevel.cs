using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressLevel : MonoBehaviour {

    //Stress Level of the character
    private int stress = 0;


    //Increase current stress level
    public void AddStress(int valueToAdd)
    {
        this.stress += valueToAdd;
    }

    //Decrease current stress level
    public void RemoveStress(int valueToRemove)
    {
        this.stress -= valueToRemove;
    }

    //Get the current stress level of the character
    public int GetStressLevel()
    {
        return this.stress;
    }

}
