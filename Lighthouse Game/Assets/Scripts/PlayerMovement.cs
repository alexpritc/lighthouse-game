using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 2.5f;

    private float jumpSpeed = 10f;
    private float gravity = 10f;
    private float velocity = 10f;

    private Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement() 
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Local movement.
        move = transform.right * x + transform.forward * z;

        transform.position += move * speed * Time.deltaTime;
    }
}
