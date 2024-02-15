using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("General")]
    public float gravityScale = -20;

    [Header("Movement")]
    public float walkSpeed = 2.5f;
    public float runSpeed = 7.5f;

    [Header("Jump")]
    public float jumpHeight = 2f;
    public AudioSource jumpSound;
    public AudioClip jumpClip;

    private Vector3 moveInput = Vector3.zero;

    CharacterController characterController;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        jumpSound = gameObject.AddComponent<AudioSource>();
        jumpSound.clip = jumpClip;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (characterController.isGrounded)
        {
            HandleMovementInput();
            HandleJumpInput();
        }

        moveInput.y += gravityScale * Time.deltaTime;
        characterController.Move(moveInput * Time.deltaTime);
    }

    private void HandleMovementInput()
    {
        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        moveInput = Vector3.ClampMagnitude(moveInput, 1f);

        float speed = Input.GetButton("Sprint") ? runSpeed : walkSpeed;
        moveInput = transform.TransformDirection(moveInput) * speed;
    }

    private void HandleJumpInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            moveInput.y = Mathf.Sqrt(jumpHeight * -2f * gravityScale);
            jumpSound.Play();
        }
    }
}
