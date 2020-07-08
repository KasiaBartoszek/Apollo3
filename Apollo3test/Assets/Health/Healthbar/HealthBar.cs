using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
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

    
    public void initSlider(int minValue, int maxValue, int actualValue)
    {
        slider.minValue = minValue;
        slider.maxValue = maxValue;
        slider.value = actualValue;
    }

    public void setSlider(int val)
    {
        slider.value = val;
    }
}
