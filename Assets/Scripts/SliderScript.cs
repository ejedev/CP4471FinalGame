using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    
    public Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        float sliderValue = slider.value;
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);   
    }
}
