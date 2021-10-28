using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This code was written following a youtube tutorial by channel Brackeys
  The video is called FIRST PERSON MOVEMENT in unity -FPS Controller, posted on Oct 27, 2019
 link: https://www.youtube.com/watch?v=_QajrabyTJc */

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;  //link to the character controller component

    public float speed = 12f;   //speed for the walking movement
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //a physics check with parameters grounddist as radius and groundmask as layermask 
       
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; //create a direction for the direction we want to move
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); //again multiple by time according to dY = 0.5*g*t^2
    }
}
