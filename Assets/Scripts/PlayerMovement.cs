using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    public Camera playerCamera;

    [Header("Movement")]
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 20f;

    [Header("Mouse Look")]
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    [Header("Crouch")]
    public float defaultHeight = 2f;
    public float crouchHeight = 1f;
    public float crouchSpeed = 3f;

    private CharacterController characterController;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0f;

    private bool canMove = true;
    private bool isCrouching = false;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();

       // Cursor.lockState = CursorLockMode.Locked;
      //  Cursor.visible = false; 
        
    }

    private void Update()
    {
        if (!canMove)
            return;

        HandleMovement();
        HandleLook();
        HandleCrouch();
    }

    private void HandleMovement()
    {
        // WASD
        Vector2 input = Vector2.zero;

        if (Keyboard.current != null)
        {
            input = new Vector2(
                Keyboard.current.aKey.isPressed ? -1 : Keyboard.current.dKey.isPressed ? 1 : 0,
                Keyboard.current.sKey.isPressed ? -1 : Keyboard.current.wKey.isPressed ? 1 : 0
            );

            input = Vector2.ClampMagnitude(input, 1f);
        }

        float currentSpeed;

        // Shift = correr
        bool isRunning = Keyboard.current != null &&
                         Keyboard.current.leftShiftKey.isPressed;

        if (isCrouching)
        {
            currentSpeed = crouchSpeed;
        }
        else if (isRunning)
        {
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }

        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        Vector3 horizontalMovement =
            (forward * input.y + right * input.x) * currentSpeed;

        moveDirection.x = horizontalMovement.x;
        moveDirection.z = horizontalMovement.z;

        // Gravidade
        if (characterController.isGrounded)
        {
            if (moveDirection.y < 0)
                moveDirection.y = -2f;

            // Space = saltar
            if (Keyboard.current != null &&
                Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                moveDirection.y = jumpPower;
            }
        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void HandleLook()
    {
        if (Mouse.current == null)
            return;

        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        rotationX += -mouseDelta.y * lookSpeed * 0.01f;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

        playerCamera.transform.localRotation =
            Quaternion.Euler(rotationX, 0f, 0f);

        transform.rotation *=
            Quaternion.Euler(0f, mouseDelta.x * lookSpeed * 0.01f, 0f);
    }

    private void HandleCrouch()
    {
        if (Keyboard.current == null)
            return;

        // R = agachar
        if (Keyboard.current.rKey.isPressed)
        {
            isCrouching = true;
            characterController.height = crouchHeight;
        }
        else
        {
            isCrouching = false;
            characterController.height = defaultHeight;
        }
    }
}