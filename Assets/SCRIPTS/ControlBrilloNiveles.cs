using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using UnityEngine.UI;

public class ControlBrilloNiveles : MonoBehaviour
{
    public Image panelBrillo;
    public float brilloPanel;

    void Start()
    {
        brilloPanel = PlayerPrefs.GetFloat("brillo", 0.5f);

        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, brilloPanel);
    }
}
