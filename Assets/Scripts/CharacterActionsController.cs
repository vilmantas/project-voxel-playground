using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class CharacterActionsController : MonoBehaviour
{
    [Range(1, 100)]
    public float MovementSpeed = 5f;

    public float MouseSpeed = 5;

    [Range(1, 100)]
    public float Gravity = 9.8f;

    public bool UseGravity = true;

    PlayerInputActions playerInput;
    CharacterController characterController;
    Animator animator;

    Vector2 currentMovementInput;
    Vector3 currentMovement;
    public bool isMovementPrssed;

    float currentRotationX;

    int isMovingHash;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Awake()
    {

        isMovingHash = Animator.StringToHash("IsMoving");

        playerInput = new PlayerInputActions();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        playerInput.CharacterControls.Move.started += HandleMovement;
        playerInput.CharacterControls.Move.performed += HandleMovement;
        playerInput.CharacterControls.Move.canceled += HandleMovement;

        playerInput.CharacterControls.ActivateMainhand.started += ctx => {
            var c = GetComponentInChildren<MainHandComponent>();
            if (c != null)
                c.Activate();
        };

        playerInput.CharacterControls.ActivateOffhand.started += ctx => {
            var c = GetComponentInChildren<OffhandComponent>();
            if (c != null)
                c.Activate();
        };

        playerInput.CharacterControls.Rotate.started += HandleRotation;

        playerInput.CharacterControls.Rotate.performed += HandleRotation;

        playerInput.CharacterControls.Rotate.canceled += HandleRotation;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleAnimation();
        HandleRotation();
        HandleGravity();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody
        if (body == null || body.isKinematic)
        {
            return;
        }

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        body.velocity = pushDir * 5;
    }

    void HandleGravity()
    {
        if (characterController.isGrounded)
        {
            float groundedGravity = -.05f;
            currentMovement.y = groundedGravity;
        } else
        {
            currentMovement.y -= Gravity;
        }
    }

    void HandleMovement()
    {
        characterController.Move(transform.rotation * currentMovement * MovementSpeed * Time.deltaTime);
    }

    void HandleRotation()
    {
        transform.rotation *= Quaternion.Euler(0, currentRotationX * MouseSpeed * Time.deltaTime, 0);
    }

    void HandleAnimation()
    {
        bool isMoving = animator.GetBool(isMovingHash);

        if (isMovementPrssed && !isMoving)
        {
            animator.SetBool(isMovingHash, true);
        } else if (!isMovementPrssed && isMoving)
        {
            animator.SetBool(isMovingHash, false);
        }
    }

    private void HandleMovement(CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        var z = transform;
        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;
        isMovementPrssed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }

    private void HandleRotation(CallbackContext context)
    {
        var loc = context.ReadValue<Vector2>();
        currentRotationX = loc.x;
        ////var MouseY = -Input.GetAxis("Mouse Y") * 5 * Time.deltaTime;
    }

    private void OnEnable()
    {
        if (playerInput != null) playerInput.CharacterControls.Enable(); 
    }

    private void OnDisable()
    {
        if (playerInput != null) playerInput.CharacterControls.Disable(); 
    }
}
