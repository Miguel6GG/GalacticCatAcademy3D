using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject Menu;
    public GameObject MenuNiveles;

    void Start()
    {
        
    }

    public void IrMenuPrincipal()
    {
        LeanTween.moveX(Menu.GetComponent<RectTransform>(), 0, 1.5f);
        LeanTween.moveX(MenuNiveles.GetComponent<RectTransform>(), 1000, 1.5f);
    }

    public void IrNiveles()
    {
        LeanTween.moveX(Menu.GetComponent<RectTransform>(), -1000, 1.5f);
        LeanTween.moveX(MenuNiveles.GetComponent<RectTransform>(), 0, 1.5f);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
