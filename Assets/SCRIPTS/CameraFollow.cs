using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objetivo; // El transform del personaje que quieres seguir
    public float suavidadRotacion = 5f; // Controla la suavidad de la rotaci�n de la c�mara

    private Vector3 offset; // La diferencia de posici�n inicial entre la c�mara y el personaje

    void Start()
    {
        offset = transform.position - objetivo.position; // Calcula la diferencia de posici�n inicial
    }

    void FixedUpdate()
    {
        // Obtiene la nueva posici�n de la c�mara basada en la posici�n del personaje m�s el offset
        Vector3 nuevaPosicion = objetivo.position + offset;
        transform.position = nuevaPosicion;

        // Calcula la rotaci�n deseada de la c�mara
        Quaternion rotacionDeseada = Quaternion.LookRotation(objetivo.position - transform.position);

        // Suaviza la rotaci�n de la c�mara
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, suavidadRotacion * Time.deltaTime);
    }
}
