using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class OpcionesBrillo : MonoBehaviour
{
    public Slider sliderBrillo;

    public PostProcessProfile brightness;

    AutoExposure exposure;

    void Start()
    {
        brightness.TryGetSettings(out exposure);
        AjustarBrillo(sliderBrillo.value);
    }

    public void AjustarBrillo(float value)
    {
        if (value != 0)
        {
            exposure.keyValue.value = value;
            print("Gilipollas");
        }
        else
        {
            exposure.keyValue.value = .05f;
            print("Subnormal");
        }
    }
}
