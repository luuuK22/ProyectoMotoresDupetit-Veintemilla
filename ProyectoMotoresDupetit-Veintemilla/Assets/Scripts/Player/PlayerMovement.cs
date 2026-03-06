using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TP2 - MATEO DUPETIT

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{


    public float walkSpeed;
    public float runSpeed;
    public float jumpPower;
    public float gravity;

    public float defaultHeight;
    public float crouchHeight;
    public float crouchSpeed;

    private float standSpeed;
    private float runStandSpeed;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController characterController;
    private bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        standSpeed = walkSpeed;
        runStandSpeed = runSpeed;
    }

    void OnEnable()
    {
        if (characterController == null)
            characterController = GetComponent<CharacterController>();

        moveDirection = Vector3.zero;
    }

    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float inputVertical = Input.GetAxis("Vertical");
        float inputHorizontal = Input.GetAxis("Horizontal");

        Vector3 inputDirection = new Vector3(inputHorizontal, 0, inputVertical);
        if (inputDirection.magnitude > 1) inputDirection.Normalize();

        float curSpeed = canMove ? (isRunning ? runSpeed : walkSpeed) : 0f;

        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * inputDirection.z + right * inputDirection.x) * curSpeed;

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            moveDirection.y = jumpPower;
        else
            moveDirection.y = movementDirectionY;

        if (!characterController.isGrounded)
            moveDirection.y -= gravity * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftControl) && canMove)
        {
            characterController.height = crouchHeight;
            walkSpeed = crouchSpeed;
            runSpeed = crouchSpeed;
        }
        else
        {
            characterController.height = defaultHeight;
            walkSpeed = standSpeed;
            runSpeed = runStandSpeed;
        }

        characterController.Move(moveDirection * Time.deltaTime);

    }
}




