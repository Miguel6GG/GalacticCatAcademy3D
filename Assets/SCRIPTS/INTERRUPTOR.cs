using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTERRUPTOR : MonoBehaviour
{
    public plataformaMovil plataforma; // Referencia a la plataforma que se activará
    public BotonPulsado boton; // Referencia a la plataforma que se activará

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            plataforma.Activar(); // Activar la plataforma cuando el jugador entra en contacto con el interruptor
            boton.Activar(); // Activar la plataforma cuando el jugador entra en contacto con el interruptor
        }
    }
}