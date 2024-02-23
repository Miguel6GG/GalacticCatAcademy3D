using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public Transform puntoInicial;
    public Transform puntoFinal;
    public float velocidad = 2.0f;

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
            transform.position = Vector3.MoveTowards(transform.position, posicionFinal, velocidad * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionInicial, velocidad * Time.deltaTime);
        }
    }

    public void Activar()
    {
        activada = !activada;
    }
}
