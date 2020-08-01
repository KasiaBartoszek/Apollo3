using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{
    public Slider slider;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    
    public void initSlider(float minValue, float maxValue, float actualValue)
    {
        slider.minValue = minValue;
        slider.maxValue = maxValue;
        slider.value = actualValue;
    }

    public void setSlider(float val)
    {
        slider.value = val;
    }
}
