using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpeechCaught : MonoBehaviour {


    public float delay = 3f;

    //Disables the gameObject after the stated delay
    public IEnumerator Start()
    {
        if (PlayerData.caughtOnce)
        {
            this.GetComponent<Image>().enabled = true;
            transform.GetChild(0).GetComponent<Text>().enabled = true;
            PlayerData.caughtOnce = false;
            yield return new WaitForSeconds(delay);
           gameObject.SetActive(false);

        }
    }


}
