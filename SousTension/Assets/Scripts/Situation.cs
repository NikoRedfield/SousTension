using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Situation : MonoBehaviour
{

    public float delay;
    public GameObject[] screens;
    public string nextScene;

    private int currentIndex = 0;

    private void Start()
    {
        StartCoroutine(SkipDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown || Input.GetButtonDown("Submit"))
        {
            if (currentIndex != screens.Length - 1)
            {
                screens[currentIndex].SetActive(false);
                currentIndex++;
                StopAllCoroutines();
                screens[currentIndex].SetActive(true);
                StartCoroutine(SkipDelay());
            }

            else
            {
                SceneManager.LoadScene(nextScene);
            }


        }

    }

    IEnumerator SkipDelay()
    {
        yield return new WaitForSeconds(delay);
        if(currentIndex == screens.Length - 1)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            screens[currentIndex].SetActive(false);
            currentIndex++;
            StopAllCoroutines();
            screens[currentIndex].SetActive(true);
            StartCoroutine(SkipDelay());
        }
    }
}
