using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 20f;

    [Header("Camera")]
    public Camera playerCamera;
    public bool rotateTowardsMovement = true;
    public float rotationSpeed = 10f;

    [Header("Crouch")]
    public float defaultHeight = 2f;
    public float crouchHeight = 1f;
    public float crouchSpeed = 3f;

    private CharacterController characterController;

    private Vector3 moveDirection = Vector3.zero;

    private bool canMove = true;
    private bool isCrouching = false;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();

        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }

        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
    }

    private void Update()
    {
        if (!canMove)
            return;

        HandleMovement();
        HandleCrouch();
    }

    private void HandleMovement()
    {
        Vector2 input = Vector2.zero;

        if (Keyboard.current != null)
        {
            input = new Vector2(
                Keyboard.current.aKey.isPressed ? -1 :
                Keyboard.current.dKey.isPressed ? 1 : 0,

                Keyboard.current.sKey.isPressed ? -1 :
                Keyboard.current.wKey.isPressed ? 1 : 0
            );

            input = Vector2.ClampMagnitude(input, 1f);
        }

        float currentSpeed;

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

        Vector3 cameraForward = playerCamera.transform.forward;
        Vector3 cameraRight = playerCamera.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 horizontalMovement =
        (cameraForward * input.y +
        cameraRight * input.x) * currentSpeed;

        moveDirection.x = horizontalMovement.x;
        moveDirection.z = horizontalMovement.z;

        if (rotateTowardsMovement &&
            horizontalMovement.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation =
            Quaternion.LookRotation(horizontalMovement);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        if (characterController.isGrounded)
        {
            if (moveDirection.y < 0)
                moveDirection.y = -2f;

            // Space = jump
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

    private void HandleCrouch()
    {
        if (Keyboard.current == null)
            return;

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
