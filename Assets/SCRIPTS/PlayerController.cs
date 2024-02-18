using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 200f;
    public float jumpForce = 500f; // Ajusta la fuerza del salto seg�n sea necesario

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true; // Habilitar la gravedad
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontalInput, 0f, verticalInput);
        move = transform.TransformDirection(move);
        rb.velocity = move * speed;

        // Verificar si el objeto est� en el suelo
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        // Verificar si se presiona el bot�n de salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
