using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnHole : MonoBehaviour {

    public Vector2 respawnPos;
    public FadeManager fade;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            fade.Fade(false, 1f);
            col.gameObject.transform.position = respawnPos;
        }
    }

}
