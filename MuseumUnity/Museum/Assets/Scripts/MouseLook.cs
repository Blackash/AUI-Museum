using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float rotationSensitivity = 100f;

    public Transform playerBody;
    
    private float xRotation = 0f;

    private bool rotationLeft = false;
    private bool rotationRight = false;
    private int rotation = 0;
    private bool blockKeyboardRotation = true;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            if (blockKeyboardRotation)
                blockKeyboardRotation = false;
            else
                blockKeyboardRotation = true;
        }
        

        //float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //float rotationCamera = Input.GetAxis("Horizontal") * rotationSensitivity * Time.deltaTime;
        float rotationCamera =rotation * rotationSensitivity * Time.deltaTime;

        if (!blockKeyboardRotation)
        {
            rotationCamera = Input.GetAxis("Horizontal") * rotationSensitivity * Time.deltaTime;
        }

        //xRotation -= rotationCamera;
        //xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * rotationCamera);


    }


    public void CameraRotationLeft(bool val)
    {

        if (val)
            rotation = -1;
        else
            rotation = 0;
        
    }

    public void CameraRotationRight(bool val)
    {
        if (val)
            rotation = 1;
        else
            rotation = 0;

    }
}
