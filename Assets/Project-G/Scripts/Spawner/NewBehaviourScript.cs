using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slider_mover : MonoBehaviour
{
    public Slider slider;
    public Text text;
    private float Value = 0;
    private int p = 0;


    public void slider_plus()
    {
        if (Value < 1f)
        {
            Value += 0.1f;
            p += 10;
        }
        text.text = p.ToString() + "%";
        slider.GetComponent<Slider>().value = Value;
    }
    public void slider_minus()
    {
        if (Value > 0.01f)
        {
            Value -= 0.1f;
            p -= 10;
        }
        text.text = p.ToString() + "%";
        slider.GetComponent<Slider>().value = Value;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
