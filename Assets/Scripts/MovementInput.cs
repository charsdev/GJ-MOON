using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementInput : MonoBehaviour
{
    public Vector2 inputVector;
    private Vector3 desiredMoveDirection;
    public bool blockRotationPlayer;
    public float desiredRotationSpeed;
    public float speedRotation;
    public float allowPlayerRotation;
    public Camera cam;
    public CharacterController controller;
    public bool isGrounded;
    public float verticalVelocity;
    private Vector3 moveVector;

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {

        if (controller.isGrounded)
        {
            desiredMoveDirection.y -= 0;
           /// desiredMoveDirection = transform.TransformDirection(moveDirection);
            //desiredMoveDirection *= speed;
            //if (Input.GetButton("Jump"))
            //    moveDirection.y = jumpSpeed;
        }
        else
        {
            desiredMoveDirection.y -= gravity * Time.deltaTime;
        }

        // desiredMoveDirection.y -= gravity * Time.deltaTime;

        controller.Move(desiredMoveDirection * speed * Time.deltaTime);


        InputMagnitude();
     }

    public void MoveRotation()
    {
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        desiredMoveDirection = forward * Input.GetAxis("Vertical") + right * Input.GetAxis("Horizontal");

        if (!blockRotationPlayer)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
        }
        
    }

    public void InputMagnitude()
    {
        inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        speedRotation = inputVector.sqrMagnitude;

        if (speedRotation > allowPlayerRotation)
        {
            MoveRotation();
        }
    }
}


