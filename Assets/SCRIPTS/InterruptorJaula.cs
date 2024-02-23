using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorJaula : MonoBehaviour
{
    public JaulaMovil jaula;
    private bool activado = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !activado)
        {
            jaula.Activar();
            activado = true;
        }
    }
}
