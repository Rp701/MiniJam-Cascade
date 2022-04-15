using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 15f;
    Rigidbody rb;
    public float jumpHeight = 7.5f;
    public Animator Player;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Code Works");
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (isGrounded() && Input.GetButton("Jump"))
        {
            rb.velocity = Vector3.up * jumpHeight;
        }
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        rb.MovePosition(transform.position + input * Time.deltaTime * movementSpeed);
    }

    public bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
