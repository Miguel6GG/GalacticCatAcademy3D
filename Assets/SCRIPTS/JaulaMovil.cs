using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaulaMovil : MonoBehaviour
{
    public Transform puntoInicial; // Punto de inicio de la jaula
    public Transform puntoFinal; // Punto final de la jaula
    public float velocidad = 2.0f; // Velocidad de movimiento de la jaula

    private Vector3 posicionInicial;
    private Vector3 posicionFinal;
    private bool activada = false;

    private void Start()
    {
        posicionInicial = puntoInicial.position;
        posicionFinal = puntoFinal.position;
    }

    private void Update()
    {
        if (activada)
        {
            // Mover la jaula hacia el punto final
            transform.position = Vector3.MoveTowards(transform.position, posicionFinal, velocidad * Time.deltaTime);
        }
        else
        {
            // Mover la jaula hacia el punto inicial
            transform.position = Vector3.MoveTowards(transform.position, posicionInicial, velocidad * Time.deltaTime);
        }
    }

    public void Activar()
    {
        activada = !activada; // Cambiar el estado de activación
    }
}
