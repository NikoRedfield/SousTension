using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour {

    private Slider brightnessSlider;
    private Slider volumeSlider;

    void Start () {
        brightnessSlider = GameObject.Find("BrightnessSlider").GetComponent<Slider>();
        volumeSlider = GameObject.Find("MusicVolumeSlider").GetComponent<Slider>();
        brightnessSlider.Select();
    }


    public void AdjustAmbientLight()
    {
        RenderSettings.ambientLight = new Color(brightnessSlider.value,brightnessSlider.value,brightnessSlider.value, 1);
    }

    public void AdjustVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
}
