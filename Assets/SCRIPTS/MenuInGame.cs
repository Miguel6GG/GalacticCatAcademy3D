using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInGame : MonoBehaviour
{
    public GameObject pauseMenu;

    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void Pausa()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Continuar()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void VolverMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
        isPaused = false;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton9)) || Input.GetKeyDown(KeyCode.JoystickButton8))
        {
            if (!isPaused)
            {
                Pausa();
            }
            else
            {
                Continuar();
            }
        }
    }
}
