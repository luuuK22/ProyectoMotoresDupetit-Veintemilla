using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TPFINAL  - LUCA VEINTEMILLA

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{


    public float walkSpeed;
    public float runSpeed;
    public float jumpPower;
    public float gravity;

 

 

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController characterController;
    private bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
       
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

        

        characterController.Move(moveDirection * Time.deltaTime);

    }



    public IEnumerator SpeedBoost(float multiplier, float duration)
    {
        runSpeed *= multiplier;
        walkSpeed *= multiplier;

        yield return new WaitForSeconds(duration);

        runSpeed /= multiplier;
        walkSpeed /= multiplier;
    }

    public IEnumerator JumpBoost(float multiplier, float duration)
    {
        jumpPower *= multiplier;

        yield return new WaitForSeconds(duration);

        jumpPower /= multiplier;
    }


}




