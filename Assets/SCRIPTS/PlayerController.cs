using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5;
    [SerializeField] private float jumpForce = 5;
    [SerializeField] private float gravity = 9.81f;

    private CharacterController controller;
    private Animator animator;

    private float verticalSpeed;
    private Vector3 lastMovementDirection;
    private bool isJumping = false;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        bool isGrounded = controller.isGrounded;

        if (isGrounded)
        {
            HandleGroundedMovement();
        }
        else
        {
            HandleAirborneMovement();
        }

        HandleRotation();

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalInput * movementSpeed, verticalSpeed, verticalInput * movementSpeed) * Time.deltaTime;
        controller.Move(movement);

        UpdateAnimations(horizontalInput, verticalInput, isGrounded);
    }

    private void HandleGroundedMovement()
    {
        if (Input.GetButtonDown("Jump"))
        {
            verticalSpeed = jumpForce;
            isJumping = true; // Set IsJumping to true when jumping
        }
        else
        {
            verticalSpeed = -gravity * Time.deltaTime;
            isJumping = false; // Set IsJumping to false when not jumping
        }
    }

    private void HandleAirborneMovement()
    {
        verticalSpeed -= gravity * Time.deltaTime;
        isJumping = true; // Set IsJumping to true when airborne
    }

    private void HandleRotation()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
            Quaternion newRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
            lastMovementDirection = moveDirection;
        }
    }

    private void UpdateAnimations(float horizontalInput, float verticalInput, bool isGrounded)
    {
        if (isGrounded)
        {
            if (horizontalInput != 0 || verticalInput != 0)
            {
                animator.SetBool("IsWalking", true);
            }
            else
            {
                animator.SetBool("IsWalking", false);
            }
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        animator.SetBool("IsJumping", isJumping); // Update IsJumping in the animator
    }
}
