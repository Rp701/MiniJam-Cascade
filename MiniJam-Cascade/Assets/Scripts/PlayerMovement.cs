using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Code Works");
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        rb.MovePosition(transform.position + input * Time.deltaTime * movementSpeed);
    }
}
