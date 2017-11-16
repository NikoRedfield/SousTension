using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictPlayer : MonoBehaviour {

    private UnityStandardAssets._2D.Platformer2DUserControl playerMovement1;
    private UnityStandardAssets._2D.PlatformerCharacter2D playerMovement2;

    // Use this for initialization
    void Start () {
        playerMovement1 = this.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>();
        playerMovement2 = this.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();

    }
	
    public void SwitchActivation()
    {
        playerMovement1.enabled = !playerMovement1.isActiveAndEnabled;
        playerMovement2.enabled = !playerMovement2.isActiveAndEnabled;
    }
}
