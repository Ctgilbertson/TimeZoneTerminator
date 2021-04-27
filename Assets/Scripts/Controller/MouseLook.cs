using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 10f;

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
        playerBody.Rotate(Vector3.up * mouseX);
       // playerBody.rotation = Quaternion.Euler(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    }
}

/*
 * using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    private Rigidbody rb;
    float rotationY = 0F;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
            rb.freezeRotation = true;
    }

    void Update()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
    }
}
*/
