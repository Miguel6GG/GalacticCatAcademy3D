using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objetivo;
    public float suavidadRotacion = 5f;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - objetivo.position;
    }

    void FixedUpdate()
    {
        // Obtiene la nueva posici�n de la c�mara basada en la posici�n del personaje m�s el offset
        Vector3 nuevaPosicion = objetivo.position + offset;
        transform.position = nuevaPosicion;

        // Calcula la rotaci�n deseada de la c�mara solo en el eje Y
        Quaternion rotacionDeseada = Quaternion.LookRotation(objetivo.position - transform.position);
        rotacionDeseada.x = 0;
        rotacionDeseada.z = 0;

        // Suaviza la rotaci�n de la c�mara solo en el eje Y
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, suavidadRotacion * Time.deltaTime);
    }
}
