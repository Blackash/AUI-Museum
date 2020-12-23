 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.InteropServices;



public class PlayerMovement : MonoBehaviour
{
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);
    int xPos = 30, yPos = 1000;
   
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
        //Vector3 move = transform.right * x * 0  + transform.forward * z ;
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            SetCursorPos(xPos, yPos);//Call this when you want to set the mouse position
        }
        //controllerChar.Move(move * speed * Time.deltaTime);

        currentVelocity.y += gravity * Time.deltaTime;

        controllerChar.Move(currentVelocity * Time.deltaTime);
        



    }

    private void FixedUpdate()
    {
        MovePlayer();
    }


    public void MovePlayer()
    {
        TrackerPlayerPosition tracker = FindObjectOfType<TrackerPlayerPosition>();
        
        if(tracker.transform.position.z > 3)
        {
            Vector3 move = transform.right * 0 + transform.forward * 1;
            controllerChar.Move(move * speed * Time.fixedDeltaTime);
        }
        if (tracker.transform.position.z < 0)
        {
            Vector3 move = transform.right * 0 + transform.forward * -1;
            controllerChar.Move(move * speed * Time.fixedDeltaTime);
        }
       
    }
}
