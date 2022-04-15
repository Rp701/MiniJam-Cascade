using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    public float moveSpeed;
    public float walkSpeed;
    public float runSpeed;
    public float JumpHeight;

    private Vector3 moveDirection;
    private Vector3 velocity;

    public bool isGrounded;
    public float groundCheckDistance;
    public LayerMask groundMask;
    public float gravity;

    //References

    private CharacterController controller;
    public Animator anim;


    private void Start()
    {
        controller = GetComponent <CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3 (0, 0, moveZ);

        if(isGrounded)
        {
            if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                //Walk
                Walk();
            }
            else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                //Run
                Run();
            }
            else if(moveDirection == Vector3.zero)
            {
                //Idle
                Idle();
            }  
            moveDirection *= moveSpeed; 

            if(Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    void Idle()
    {
        anim.SetFloat("Speed", 0f);
    }

    void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.5f);
    }

    void Run()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 1f);
    }

    void Jump()
    {
        velocity.y = Mathf.Sqrt(JumpHeight * -2 * gravity);
    }
}

