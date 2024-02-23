using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemigoMovil : MonoBehaviour
{
    public Transform puntoA;
    public Transform puntoB;
    public float velocidad = 2.0f;

    private Vector3 objetivo;
    private bool enMovimiento = true;

    void Start()
    {
        objetivo = puntoB.position;
    }

    void Update()
    {
        if (enMovimiento)
        {
            MoverEnemigo();
        }
    }

    void MoverEnemigo()
    {
        transform.position = Vector3.MoveTowards(transform.position, objetivo, velocidad * Time.deltaTime);

        if (transform.position == puntoB.position)
        {
            objetivo = puntoA.position;
        }
        else if (transform.position == puntoA.position)
        {
            objetivo = puntoB.position;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ReiniciarNivel();
        }
    }

    void ReiniciarNivel()
    {
        // Reiniciar el nivel cargando la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}