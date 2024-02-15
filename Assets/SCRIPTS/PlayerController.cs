using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del personaje

    void Update()
    {
        // Obtener la entrada de teclado para el movimiento horizontal y vertical
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular el vector de movimiento
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime;

        // Aplicar el movimiento al transform del personaje
        transform.Translate(movement, Space.World);
    }
}
