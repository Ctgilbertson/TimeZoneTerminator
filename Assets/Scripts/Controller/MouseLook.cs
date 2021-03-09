using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 999999999f;

    public Transform playerBody;
    public Transform weapons;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Hide and lock cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //gets axises and edits the variables based on sensitivity and Timedelta isthe amount of time since last fram update 
        //to account for all different frame rates
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime * 10;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime * 10;
    
        //decrease x rotation based on mouseY flipped for inversion
        xRotation -= mouseY;
        //Keep x rotation between 90 and -90 so you cant look behind when looking up and down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Vector3.up isolates the Y axis to move in relation to the mouseX
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
