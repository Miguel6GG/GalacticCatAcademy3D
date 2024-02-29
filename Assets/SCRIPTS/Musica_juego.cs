using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Musica_juego : MonoBehaviour
{
    private bool pausar;
    public MenuInGame scriptMenuInGame;
    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!scriptMenuInGame.isPaused)
        {
            mixer.SetFloat("LowPass", 19000);
        }
        else
        {
            mixer.SetFloat("LowPass", 500);
        }
    }
}
