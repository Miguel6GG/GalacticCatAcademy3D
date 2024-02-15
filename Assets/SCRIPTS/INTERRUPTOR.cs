using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTERRUPTOR : MonoBehaviour
{
    public GameObject plataforma; // La plataforma que queremos activar
    public float alturaMaxima = 5f; // Altura m�xima a la que se elevar� la plataforma
    public float velocidadElevacion = 2f; // Velocidad a la que se elevar� la plataforma

    private bool activado = false; // Variable para controlar si el interruptor est� activado

    private Vector3 posicionInicialPlataforma; // Posici�n inicial de la plataforma

    // Start is called before the first frame update
    void Start()
    {
        // Guardamos la posici�n inicial de la plataforma
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
            // Llamamos a la funci�n para elevar la plataforma
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