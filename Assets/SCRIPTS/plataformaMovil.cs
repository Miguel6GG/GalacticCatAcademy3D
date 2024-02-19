using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaMovil : MonoBehaviour
{
    public Transform puntoInicial; // Punto de inicio de la plataforma
    public Transform puntoFinal; // Punto final de la plataforma
    public float velocidad = 5.0f; // Velocidad de movimiento de la plataforma

    private Vector3 posicionInicial;
    private Vector3 posicionFinal;
    private bool activada = false;
    private bool activacionPermanente = false; // Nuevo flag para activación permanente

    private void Start()
    {
        posicionInicial = puntoInicial.position;
        posicionFinal = puntoFinal.position;
    }

    private void Update()
    {
        if (activada || activacionPermanente) // Modificamos la condición aquí
        {
            // Mover la plataforma hacia el punto final
            transform.position = Vector3.MoveTowards(transform.position, posicionFinal, velocidad * Time.deltaTime);
        }
        else
        {
            // Mover la plataforma hacia el punto inicial
            transform.position = Vector3.MoveTowards(transform.position, posicionInicial, velocidad * Time.deltaTime);
        }
    }

    public void Activar()
    {
        if (!activacionPermanente) // Solo si no es permanente, cambia el estado
            activada = !activada; // Cambiar el estado de activación
        else
            activada = true; // Si es permanente, activar siempre
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Activar(); // Activar la plataforma cuando entre en contacto con el objeto con la etiqueta "Player"
            activacionPermanente = true; // Una vez activado, se hace permanente
        }
    }
}
