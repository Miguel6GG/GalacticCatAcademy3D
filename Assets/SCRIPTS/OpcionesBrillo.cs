using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using UnityEngine.UI;

public class OpcionesBrillo : MonoBehaviour
{
    public Slider sliderBrillo;
    public float sliderValue;
    public Image panelBrillo;

    private void Start()
    {
        sliderBrillo.value = PlayerPrefs.GetFloat("brillo", 0f);

        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, sliderBrillo.value);
    }

    public void ChangeSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("brillo", sliderValue);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, sliderBrillo.value);
    }
}
