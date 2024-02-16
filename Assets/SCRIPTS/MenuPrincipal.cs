using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject Menu;
    public GameObject MenuNiveles;
    public GameObject MenuOpciones;

    void Start()
    {
        
    }

    public void IrMenuPrincipal()
    {
        LeanTween.moveX(Menu.GetComponent<RectTransform>(), 0, 1f).setEase(LeanTweenType.easeInOutBack);
        LeanTween.moveX(MenuNiveles.GetComponent<RectTransform>(), 1000, 1f).setEase(LeanTweenType.easeInOutBack);
    }

    public void IrNiveles()
    {
        LeanTween.moveX(Menu.GetComponent<RectTransform>(), -1000, 1f).setEase(LeanTweenType.easeInOutBack);
        LeanTween.moveX(MenuNiveles.GetComponent<RectTransform>(), 0, 1f).setEase(LeanTweenType.easeInOutBack);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
