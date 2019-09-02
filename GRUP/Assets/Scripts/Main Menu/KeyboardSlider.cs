using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardSlider : MonoBehaviour
{
    float minValue = -50f, maxValue = 10f, variationAmount = 5f;
    public Slider sliderRef;

    private void Start()
    {
        sliderRef = this.gameObject.GetComponent<Slider>();
        sliderRef.minValue = minValue;
        sliderRef.maxValue = maxValue;
    }

    public void Update()
    {
        ActivateSlider();
    }

    public void ActivateSlider()
    {
        if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
        {
            sliderRef.value -= variationAmount;
        }
        else if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
        {
            sliderRef.value += variationAmount;
        }
    }
}
