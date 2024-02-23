using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5;
    [SerializeField] float jumpForce = 5;
    [SerializeField] float gravity = 9.81f;

    CharacterController controller;
    Animator animator;

    float verticalSpeed;
    Vector3 lastMovementDirection;

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
            {
                verticalSpeed = jumpForce;
                animator.SetTrigger("Jump");
            }
            else
            {
                verticalSpeed = -1;
                if (lastMovementDirection.magnitude > 0)
                    animator.SetBool("IsWalking", true);
                else
                    animator.SetBool("IsWalking", false);
            }
        }
        else
        {
            verticalSpeed -= gravity * Time.deltaTime;
            animator.SetBool("IsWalking", false);
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalInput * movementSpeed, verticalSpeed, verticalInput * movementSpeed) * Time.deltaTime;
        controller.Move(movement);

        // Rotate the character
        if (horizontalInput != 0 || verticalInput != 0)
        {
            Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
            Quaternion newRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
            lastMovementDirection = moveDirection;
        }
    }
}
