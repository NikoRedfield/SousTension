﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FadeManager : MonoBehaviour {

    public static FadeManager Instance { set; get; }
    public Image fadeImage;
    public bool launchFadeEffect = false;

    private bool isShowing;
    private float duration;
    private float transition;
    private bool isTransition;

    
    //Instanciate Fade Manager
    private void Awake()
    {
        Instance = this;

        Fade(false, 3f);

    }

    //Engage the Fading Effect
    public void Fade(bool showing, float duration)
    {
        isShowing = showing;
        isTransition = true;
        this.duration = duration;
        transition = (isShowing) ? 0 : 1;
    }

    //Manage the transition used for the fading effect
    private void Update()
    {
        
            
   

        if (!isTransition)
        {
            return;
        }

        transition += (isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
        fadeImage.color = Color.Lerp(new Color(1, 1, 1, 0), Color.black, transition);

        if(transition > 1 || transition < 0) //transition is over
        {
            isTransition = false;
        }
        
    }
}
