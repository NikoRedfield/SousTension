using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInactiveAfterDelay : MonoBehaviour {

    public float delay = 5f;

    public bool setActive = false;

    //Disables the gameObject after the stated delay
    public IEnumerator Start()
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(setActive);
    }

}
