using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour {

    public GameObject obj;

    //Trigger for activating a given game object
    private void OnTriggerEnter2D(Collider2D col) {
        obj.SetActive(true);
            }
}
