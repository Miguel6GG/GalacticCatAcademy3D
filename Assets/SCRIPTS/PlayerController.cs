using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5;
    [SerializeField] float jumpForce = 5;
    [SerializeField] float gravity = 9.81f;

    CharacterController controller;
    Animator animator;

    float verticalSpeed;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
                verticalSpeed = jumpForce;
            else
                verticalSpeed = -1;
        }
        else
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalInput * movementSpeed, verticalSpeed, verticalInput * movementSpeed) * Time.deltaTime;
        controller.Move(movement);
    }
}
