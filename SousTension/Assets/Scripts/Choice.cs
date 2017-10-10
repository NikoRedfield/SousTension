using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour {

    public bool affectStress = false;
    public int impactOnStress = 0;
    public Dialogue dialogue;

    private StressLevel stress;
    private GameObject player;
    private GameObject choice;



    public void MakeChoice()
    {
        if (affectStress)
        {
            player = GameObject.Find("Player");
            stress = player.GetComponent<StressLevel>();
            stress.AddStress(impactOnStress);
        }
        choice = GameObject.FindGameObjectWithTag("ChoiceUI");
       // dialogue.StartDialogue();
        
    }
}
