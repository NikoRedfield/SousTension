using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadAfterTime : MonoBehaviour
{

    public string _nextScene = "";

    public float _delay = 5f;


    //Load the given scene after the stated delay
    public IEnumerator Start()
    {
        yield return new WaitForSeconds(_delay);
        SceneManager.LoadScene(_nextScene);
    }
}
