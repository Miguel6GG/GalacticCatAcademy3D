using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject Menu;
    public GameObject MenuNiveles;
    public GameObject MenuOpciones;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
    }
    
    public void NuevaPartida()
    {
        SceneManager.LoadScene("NIVEL_1");
    }

    public void Nivel1()
    {
        SceneManager.LoadScene("NIVEL_1");
    }
    public void Nivel2()
    {
        SceneManager.LoadScene("NIVEL_2");
    }
    public void Nivel3()
    {
        SceneManager.LoadScene("NIVEL_3");
    }
    public void Nivel4()
    {
        SceneManager.LoadScene("NIVEL_4");
    }

    public void IrMenuPrincipal()
    {
        LeanTween.moveX(Menu.GetComponent<RectTransform>(), 0, 1f).setEase(LeanTweenType.easeInOutBack);
        LeanTween.moveX(MenuNiveles.GetComponent<RectTransform>(), 1000, 1f).setEase(LeanTweenType.easeInOutBack);
        LeanTween.moveX(MenuOpciones.GetComponent<RectTransform>(), 1000, 1f).setEase(LeanTweenType.easeInOutBack);
    }

    public void IrNiveles()
    {
        LeanTween.moveX(Menu.GetComponent<RectTransform>(), -1000, 1f).setEase(LeanTweenType.easeInOutBack);
        LeanTween.moveX(MenuNiveles.GetComponent<RectTransform>(), 0, 1f).setEase(LeanTweenType.easeInOutBack);
        LeanTween.moveX(MenuOpciones.GetComponent<RectTransform>(), 0, 1f).setEase(LeanTweenType.easeInOutBack);

        LeanTween.moveY(MenuNiveles.GetComponent<RectTransform>(), 0, 0f).setEase(LeanTweenType.easeInOutBack);
        LeanTween.moveY(MenuOpciones.GetComponent<RectTransform>(), -600, 0f).setEase(LeanTweenType.easeInOutBack);
    }

    public void IrOpciones()
    {
        LeanTween.moveX(Menu.GetComponent<RectTransform>(), -1000, 1f).setEase(LeanTweenType.easeInOutBack);
        LeanTween.moveX(MenuNiveles.GetComponent<RectTransform>(), 0, 1f).setEase(LeanTweenType.easeInOutBack);
        LeanTween.moveX(MenuOpciones.GetComponent<RectTransform>(), 0, 1f).setEase(LeanTweenType.easeInOutBack);

        LeanTween.moveY(MenuNiveles.GetComponent<RectTransform>(), -600, 0f).setEase(LeanTweenType.easeInOutBack);
        LeanTween.moveY(MenuOpciones.GetComponent<RectTransform>(), 0, 0f).setEase(LeanTweenType.easeInOutBack);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
