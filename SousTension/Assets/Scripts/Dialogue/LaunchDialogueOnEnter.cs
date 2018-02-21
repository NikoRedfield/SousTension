using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchDialogueOnEnter : MonoBehaviour {

    public GameObject objectToEnable;
    public FadeManager fade;
    public Narration dialogue;
    public bool dial3 = false;
    public bool dial6 = false;
    public GameObject monster;

    private static bool done6;
    private GameObject player;
    private bool alreadyTold = false;


    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (dial3)
        {
            if (!alreadyTold && !PlayerData.objective3)
            {

                fade.Fade(false, 2f);
                objectToEnable.SetActive(true);  //Displays Dialogue UI
                player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().backward = false;
                player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().SetAuthorisation(false);
                player.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().Move(0, false, false);
                dialogue.StartDialogue();
                alreadyTold = true;
            }
        }
        if (dial6)
        {
            if (!alreadyTold && PlayerData.objective5 && PlayerData.generators && !done6)
            {

                fade.Fade(false, 2f);
                objectToEnable.SetActive(true);  //Displays Dialogue UI
                player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().backward = false;
                player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().SetAuthorisation(false);
                player.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().Move(0, false, false);
                dialogue.StartDialogue();
                monster.GetComponent<MonsterNewForm>().SetSpawn(false);
                monster.GetComponent<MonsterNewForm>().ResetFeedback();
                alreadyTold = true;
                done6 = true;
            }
        }

    }
}
