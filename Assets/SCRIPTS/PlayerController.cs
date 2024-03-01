using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5;
    [SerializeField] private float jumpForce = 5;
    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip attackSound1;
    [SerializeField] private AudioClip attackSound2;

    private CharacterController controller;
    private Animator animator;
    private AudioSource audioSource;

    private float verticalSpeed;
    private Vector3 lastMovementDirection;
    private bool isJumping = false;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("attack"))
        {
            PlayRandomAttackSound();
        }

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
            isJumping = true;
            PlayJumpSound();
        }
        else
        {
            verticalSpeed = -gravity * Time.deltaTime;
            isJumping = false;
        }
    }

    private void HandleAirborneMovement()
    {
        verticalSpeed -= gravity * Time.deltaTime;
        isJumping = true;
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
            animator.SetBool("IsWalking", horizontalInput != 0 || verticalInput != 0);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        animator.SetBool("IsJumping", isJumping);
    }

    private void PlayJumpSound()
    {
        if (jumpSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }

    private void PlayRandomAttackSound()
    {
        if (audioSource != null)
        {
            int randomIndex = Random.Range(1, 3);

            switch (randomIndex)
            {
                case 1:
                    audioSource.PlayOneShot(attackSound1);
                    break;
                case 2:
                    audioSource.PlayOneShot(attackSound2);
                    break;
                default:
                    Debug.LogError("Sonido invalido");
                    break;
            }
        }
    }
}
