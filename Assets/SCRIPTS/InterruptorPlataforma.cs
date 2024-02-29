using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorPlataforma : MonoBehaviour
{
    public PlataformaMovil plataforma;
    public BotonPulsado boton; // Referencia a la plataforma que se activar�
    private bool activado = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !activado)
        {
            plataforma.Activar();
            boton.Activar(); // Activar la plataforma cuando el jugador entra en contacto con el interruptor
            activado = true;
        }
    }
}
