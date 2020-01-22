using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAlternativeMovement : MonoBehaviour
{
    public GameObject lighthouse;
    public GameObject rot;

    private float speed = 1.25f;
    private float distanceToGround = 0.6f;
    private float gravity = -19.7f;
    private float jumpHeight = 1f;

    private Vector3 velocity;
    private Vector3 down;
    private Vector3 move;

    private CharacterController cc;

    private bool isGrounded;

    private RaycastHit hit;

    private Transform playerTransform;

    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();

        playerTransform = transform;
        isGrounded = true;
    }

    // Update is called once per frame.
    // Player input.
    void Update()
    {
        // Get jump input.
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
            //Debug.Log("Jump!");

            isGrounded = false;
        }

        // Apply gravity to velocity.
        velocity.y += gravity * Time.deltaTime;
    }

    // Physics.
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");

        // Play footstep sounds here.
        cc.Move(move * speed * Time.deltaTime);
        lighthouse.transform.RotateAround(rot.transform.position, new Vector3(0.0f, 1.0f, 0.0f), x * speed);
        //lighthouse.transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f), x, Space.World);

        // Play jump sound here.
        cc.Move(velocity * Time.deltaTime);
        GroundCheck();
    }

    void GroundCheck()
    {
        // Draw raycast downwards to check if the player is touching the ground.
        down = transform.TransformDirection(Vector3.down);

        //Debug.DrawRay(transform.position, down, Color.red);

        if (Physics.Raycast(transform.position, down, out hit, distanceToGround))
        {
            Debug.DrawRay(transform.position, down * hit.distance, Color.yellow);
            isGrounded = true;
            velocity.y = 0f;
        }
    }
}
