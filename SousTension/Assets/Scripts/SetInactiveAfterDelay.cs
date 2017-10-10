using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInactiveAfterDelay : MonoBehaviour {

    public float delay = 5f;

    public bool setActive = false;

    public IEnumerator Start()
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(setActive);
       
    }

}
