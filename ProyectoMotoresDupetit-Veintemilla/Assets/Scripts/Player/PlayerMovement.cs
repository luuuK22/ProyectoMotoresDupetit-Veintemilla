using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  

    public float speed = 5f;
    private Rigidbody rb;
    private Vector2 input;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        Vector3 move = (transform.forward * input.y + transform.right * input.x).normalized;
        
        rb.velocity = new Vector3(move.x * speed, rb.velocity.y, move.z * speed);
    }
}




