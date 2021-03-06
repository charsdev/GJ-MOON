using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    Vector3 velocity;
    bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;
    public Animator anim;
    private bool isRunning = false;
    private bool isWalking = false;
    private bool attackAnim = false;
    public bool canMove = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;

        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isRunning", isRunning);
        isWalking = false;
        isRunning = false;
        //jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        /*if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }*/
        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        /*if (Input.GetButtonDown("Fire1") && Time.timeScale == 1)
        {
            speed = 0;
            isWalking = false;
            isRunning = false;
            anim.SetBool("isWalking", isWalking);
            anim.SetBool("isRunning", isRunning);
            canMove = false;
        }*/
        if (direction.magnitude >= 0.1f && Input.GetKey(KeyCode.LeftShift) == false)
        {
            canMove = true;
            speed = 6;
            isWalking = true;
            isRunning = false;
            attackAnim = false;
            anim.SetBool("isWalking", isWalking);
            anim.SetBool("isRunning", isRunning);
            anim.SetBool("attack", attackAnim);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else if (direction.magnitude >= 0.1f && Input.GetKey(KeyCode.LeftShift) == true)
        {
            canMove = true;
            speed = 15;
            isRunning = true;
            isWalking = false;
            anim.SetBool("isRunning", isRunning);
            anim.SetBool("isWalking", isWalking);
            anim.SetBool("attack", attackAnim);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
}