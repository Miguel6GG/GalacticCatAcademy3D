using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorDesliza : MonoBehaviour
{
    public PlataformaDesliza plataforma;
    private bool activado = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !activado)
        {
            plataforma.Activar();
            activado = true;
        }
    }
}
