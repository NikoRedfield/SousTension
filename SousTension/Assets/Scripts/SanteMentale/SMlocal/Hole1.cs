using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole1 : MonoBehaviour {

    public GameObject hole;

    private int frequence;
    private int delay;
    private int defaultDelay = 240;
    private int innerDelay;
    private bool begun;
    private bool readyForEvolve;

	// Use this for initialization
	void Start () {
        delay = defaultDelay;
        innerDelay = 0;
        begun = false;
        readyForEvolve = false;
	}

    // Update is called once per frame
    void Update() {
        CheckSanteMentale();
        if (frequence != 0)
        {
            if (!begun)
            {
                Debug.Log("f = " + frequence + " delay = " + innerDelay);
                innerDelay++;
                if (innerDelay >= frequence)
                {
                    innerDelay = 0;
                    begun = true;
                }
            }
            else
            {
                if (!readyForEvolve)
                {
                    Regresse();
                }
                else
                {
                    CheckOver();
                }
                
            }
        }
        else
        {
            if (begun)
            {
                CheckOver();
            }
        }
    }

    void Regresse()
    {
        hole.SetActive(true);
        Vector3 holeScale = hole.transform.localScale;
        hole.transform.localScale = new Vector3(holeScale.x -= 0.05f, holeScale.y -= 0.05f, holeScale.z -= 0.05f);
        if (hole.transform.localScale.x <= 1)
        {
            readyForEvolve = true;
        }
        else
        {
            readyForEvolve = false;
        }
    }


    void Evolve()
    {
         Vector3 holeScale = hole.transform.localScale;
        hole.transform.localScale = new Vector3(holeScale.x += 0.05f, holeScale.y += 0.05f, holeScale.z += 0.05f);
        if(hole.transform.localScale.x >= 6)
        {
            hole.SetActive(false);
            begun = false;
        }
    }


    void CheckOver()
    {
       if (delay <= 0)
       {
                Evolve();
                if (!hole.activeSelf)
                {
                //begun = false;
                readyForEvolve = false;
                delay = defaultDelay;
                }
            }
            else
            {
                delay--;
            }
    }

              
          

    void CheckSanteMentale()
    {
        if (PlayerData.santeMentale <= (int)PlayerData.maxSanteMentale * 0.5 && PlayerData.santeMentale >= PlayerData.maxSanteMentale * 0.3)
        {
            frequence = 900;
            return;
        }
        if (PlayerData.santeMentale <= (int)PlayerData.maxSanteMentale * 0.29 && PlayerData.santeMentale >= (int)PlayerData.maxSanteMentale * 0.20)
        {
            frequence = 600;
            return;
        }
      
        else
        {
            frequence = 0;
        }
    }
}
