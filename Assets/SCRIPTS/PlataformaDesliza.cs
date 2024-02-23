using UnityEngine;

public class PlataformaDesliza : MonoBehaviour
{
    public Transform puntoInicial;
    public Transform puntoFinal;
    public float velocidad = 2.0f;

    private Vector3 posicionInicial;
    private Vector3 posicionFinal;
    private bool activada = false;
    private bool haciaPuntoFinal = true; // Variable para controlar la dirección del movimiento

    private void Start()
    {
        posicionInicial = puntoInicial.position;
        posicionFinal = puntoFinal.position;
    }

    private void Update()
    {
        if (activada)
        {
            // Movimiento hacia el punto final
            if (haciaPuntoFinal)
            {
                transform.position = Vector3.MoveTowards(transform.position, posicionFinal, velocidad * Time.deltaTime);
                if (transform.position == posicionFinal)
                    haciaPuntoFinal = false; // Cambiar dirección al llegar al punto final
            }
            // Movimiento hacia el punto inicial
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, posicionInicial, velocidad * Time.deltaTime);
                if (transform.position == posicionInicial)
                    haciaPuntoFinal = true; // Cambiar dirección al llegar al punto inicial
            }
        }
    }

    public void Activar()
    {
        activada = !activada;
    }
}
