using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    public static GameObject instance;
    private float moveSpeed; 
    [Header("Movement")]
    public float walkSpeed;
    public float runSpeed;
    public float JumpHeight;
    
    
    private Vector3 moveDirection;
    private Vector3 velocity;

    private bool isGrounded;
    [Header("Physics")]
    public float groundCheckDistance;
    public LayerMask groundMask;
    public float gravity;

    //References    

    private CharacterController controller;

    private void Awake()
    {
        instance = gameObject;
        controller = GetComponent <CharacterController>();
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
        float moveX = Input.GetAxis("Horizontal");

        moveDirection = transform.right * moveX + transform.forward * moveZ;

        if (isGrounded)
        {

            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                //Walk
                Walk();
            }

            else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                //Run
                Run();
            }

            if(Input.GetButton("Jump") && isGrounded)
            {
                Jump();
            }

        }

        moveDirection *= moveSpeed;

        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }

    void Walk()
    {
        moveSpeed = walkSpeed;
        
    }

    void Run()
    {
        moveSpeed = runSpeed;
        
    }

    void Jump()
    {
        velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
    }
}

