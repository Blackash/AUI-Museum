 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controllerChar;

    public float speed = 12f;

    public float gravity = -9.81f;
    Vector3 currentVelocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && currentVelocity.y < 0)
        {
            currentVelocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x * 0  + transform.forward * z ;

        controllerChar.Move(move * speed * Time.deltaTime);

        currentVelocity.y += gravity * Time.deltaTime;

        controllerChar.Move(currentVelocity * Time.deltaTime);




    }
}
