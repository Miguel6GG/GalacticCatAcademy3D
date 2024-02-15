using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTERRUPTOR : MonoBehaviour
{
    public GameObject plataforma; // La plataforma que queremos activar
    public float alturaMaxima = 5f; // Altura máxima a la que se elevará la plataforma
    public float velocidadElevacion = 2f; // Velocidad a la que se elevará la plataforma

    private bool activado = false; // Variable para controlar si el interruptor está activado

    private Vector3 posicionInicialPlataforma; // Posición inicial de la plataforma

    // Start is called before the first frame update
    void Start()
    {
        // Guardamos la posición inicial de la plataforma
        posicionInicialPlataforma = plataforma.transform.position;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        // Verificamos si el jugador ha entrado en contacto con el interruptor
        if (other.CompareTag("Player") && !activado)
        {
            // Activamos el interruptor
            activado = true;
            // Llamamos a la función para elevar la plataforma
            StartCoroutine(ElevarPlataforma());
        }
    }
    IEnumerator ElevarPlataforma()
    {
        float distanciaTotal = alturaMaxima - plataforma.transform.position.y;
        float tiempoTotal = distanciaTotal / velocidadElevacion;

        float tiempoTranscurrido = 0f;

        while (tiempoTranscurrido < tiempoTotal)
        {
            // Movemos la plataforma hacia arriba con una velocidad determinada
            plataforma.transform.Translate(Vector3.up * velocidadElevacion * Time.deltaTime);
            tiempoTranscurrido += Time.deltaTime;
            yield return null;
        }
    }
}