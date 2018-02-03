using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpLadder : MonoBehaviour {

    public float up = 0.3f;
    public float side = 0.4f;

    //Move the player left or right once he went up the ladder
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Input.GetAxis("Vertical") > 0)  //Going up the ladder
        {
            collision.transform.position = new Vector3(collision.transform.position.x + side, collision.transform.position.y + up, collision.transform.position.z);
        }
    }
}
