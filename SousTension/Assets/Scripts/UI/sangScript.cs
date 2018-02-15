using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class sangScript : MonoBehaviour {

    private GameObject player;
    public GameObject groupBox;
    private bool firstTime = false;
    private Vector3 wantedPos;
    private bool toLeft = false;
    private float newX;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        updateMoveBox();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && firstTime == false)
        {
            firstTime = true;
            toLeft = true;
            Debug.Log("Collision detectee");
            moveBox();
        }
    }

    private void moveBox()
    {
        wantedPos = groupBox.transform.position;
        wantedPos.x = wantedPos.x - 3;
    }

    private void updateMoveBox()
    {
        if (toLeft == true && groupBox.transform.position.x > wantedPos.x)
        {
            newX = groupBox.transform.position.x - 0.01f;
            groupBox.transform.position = new Vector3(newX, groupBox.transform.position.y, groupBox.transform.position.z);
            if (groupBox.transform.position.x <= wantedPos.x)
            {
                toLeft = false;
                wantedPos.x = wantedPos.x + 3;
            }
        }
        if (toLeft == false && groupBox.transform.position.x < wantedPos.x)
        {
            newX = groupBox.transform.position.x + 0.01f;
            groupBox.transform.position = new Vector3(newX, groupBox.transform.position.y, groupBox.transform.position.z);
        }
    }
}