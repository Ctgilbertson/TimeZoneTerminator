using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public Camera camera;

    private Vector3 originalCenter;
    private float originalHeight;
    private float originalMoveSpeed;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    //ground check object at bottom of player
    public Transform groundCheck;
    public float groundDistance = 0.4f;

    //Layer that contains all the ground objects that I am stopped by
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;
    bool crouch;


    void Start()
    {

        originalCenter = controller.center;
        originalHeight = controller.height;
        originalMoveSpeed = speed;

    }
    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Arrow in the direction that we want to move
        //transform.right takes the direction that the player is facing and goes right
        //transform.up takes the direction that the player is facing and goes forward

        //calculate jump
        if(Input.GetButtonDown("Jump")&& isGrounded){
            //Equation for jump height is sqrt(height*-2*gravity)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //set velocity to the gravity acceleration rate * the time
        velocity.y += gravity * Time.deltaTime;

        //Move the player down multiplying by time again becasue it is 1/2g *t^2
        controller.Move(velocity*Time.deltaTime);


        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed*2 * Time.deltaTime);
        }
        else
        {

            Vector3 move = transform.right*x+ transform.forward*z;

            controller.Move(move * speed * Time.deltaTime);

        }
        if (Input.GetButtonDown("Fire1") && isGrounded)
        {
            Vector3 position = Camera.main.transform.position;
            position[1] = 2f;
            Camera.main.transform.position = position;
            //controller.height = 2f;
            // controller.center = new Vector3(0f, 1f, 0f);
            // speed = 12f;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            Vector3 position = Camera.main.transform.position;
            position[1] = 4f;
            Camera.main.transform.position = position;
            //          controller.center = new Vector3(0f, -1f, 0f);
            //            controller.height = originalHeight;
            //           speed = originalMoveSpeed;
        }


    }
}
