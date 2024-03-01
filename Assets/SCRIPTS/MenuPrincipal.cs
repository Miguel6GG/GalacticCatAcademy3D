using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject Menu;
    public GameObject MenuNiveles;
    public GameObject MenuOpciones;
    public AudioMixer mixer;

    void Start()
    {
        mixer.SetFloat("LowPass", 19000);
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
    public void Nivel5()
    {
        SceneManager.LoadScene("NIVEL_5");
    }
    public void Nivel6()
    {
        SceneManager.LoadScene("NIVEL_6");
    }
    public void Nivel7()
    {
        SceneManager.LoadScene("NIVEL_7");
    }
    public void Nivel8()
    {
        SceneManager.LoadScene("NIVEL_8");
    }
    public void Nivel9()
    {
        SceneManager.LoadScene("NIVEL_9");
    }
    public void Nivel10()
    {
        SceneManager.LoadScene("NIVEL_10");
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

    public void ResetearProgreso()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
