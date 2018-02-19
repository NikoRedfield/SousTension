using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimFeu : MonoBehaviour {

    public Sprite[] lights;
    public Sprite fixedlight;

    private int spriteIndex = 0;


	// Use this for initialization
	void Start () {
        InvokeRepeating("AnimateUI", 0, 0.9f);
    }
	


    void AnimateUI()
    {
        
           this.GetComponent<SpriteRenderer>().sprite = lights[spriteIndex];
            spriteIndex++;
            if (spriteIndex > 2)
            {
                spriteIndex = 0;
            }
            Debug.Log("Sprite : " + spriteIndex);

        }

    public void SetFixed()
    {
        CancelInvoke();
        this.GetComponent<SpriteRenderer>().sprite = fixedlight;
    }


}
