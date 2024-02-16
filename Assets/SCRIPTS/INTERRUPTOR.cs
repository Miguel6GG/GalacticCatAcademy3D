using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTERRUPTOR : MonoBehaviour
{
    public PlataformaMovil plataforma; // Referencia a la plataforma que se activar�

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            plataforma.Activar(); // Activar la plataforma cuando el jugador entra en contacto con el interruptor
        }
    }
}