using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objetivo; // El transform del personaje que quieres seguir
    public float suavidadRotacion = 5f; // Controla la suavidad de la rotación de la cámara

    private Vector3 offset; // La diferencia de posición inicial entre la cámara y el personaje

    void Start()
    {
        offset = transform.position - objetivo.position; // Calcula la diferencia de posición inicial
    }

    void FixedUpdate()
    {
        // Obtiene la nueva posición de la cámara basada en la posición del personaje más el offset
        Vector3 nuevaPosicion = objetivo.position + offset;
        transform.position = nuevaPosicion;

        // Calcula la rotación deseada de la cámara
        Quaternion rotacionDeseada = Quaternion.LookRotation(objetivo.position - transform.position);

        // Suaviza la rotación de la cámara
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, suavidadRotacion * Time.deltaTime);
    }
}
