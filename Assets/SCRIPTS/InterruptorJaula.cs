using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorJaula : MonoBehaviour
{
    public JaulaMovil jaula; // Referencia a la jaula que se activará

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jaula.Activar(); // Activar la jaula cuando el jugador entra en contacto con el interruptor
        }
    }
}
