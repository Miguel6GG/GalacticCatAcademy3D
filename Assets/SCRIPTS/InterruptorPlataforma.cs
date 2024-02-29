using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorPlataforma : MonoBehaviour
{
    public PlataformaMovil plataforma;
    public BotonPulsado boton; // Referencia a la plataforma que se activar�
    public AudioClip sonidoActivacion; // Sonido a reproducir cuando se activa el interruptor
    private bool activado = false;
    private AudioSource audioSource;

    private void Start()
    {
        // Obtener el componente AudioSource del GameObject
        audioSource = GetComponent<AudioSource>();
        // Asignar el clip de audio al AudioSource
        audioSource.clip = sonidoActivacion;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !activado)
        {
            plataforma.Activar();
            boton.Activar(); // Activar la plataforma cuando el jugador entra en contacto con el interruptor
            activado = true;

            // Reproducir el sonido de activaci�n
            if (sonidoActivacion != null && audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}
