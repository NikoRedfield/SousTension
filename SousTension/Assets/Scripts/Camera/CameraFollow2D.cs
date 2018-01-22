using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour {

    
    public Camera cam;
    public Transform player;
    public Vector3 offset;
    public float limitLeft;
    public float limitRight;

    //Follow the player with a certain offset on each axes
    void Update()
    {
        if (player.position.x + offset.x > limitRight || player.position.x + offset.x < limitLeft)
        {
            return;
        }
        else
        {

            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
        }
        
    }
}
