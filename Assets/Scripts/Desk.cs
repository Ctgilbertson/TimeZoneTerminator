using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Desk : MonoBehaviour
{

    public Transform destination;
    public GameObject uiObject;
    public GameObject camera;
    public GameObject playerCamera;
    public Rigidbody rb;
    public Transform open;
    public GameObject inp;
    public string code;
    public string textCode;


    // Start is called before the first frame update
    void Start()
    {
        camera.SetActive(false);
        inp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        float dist = Vector3.Distance(this.transform.position, destination.position);

        if (dist < 5f)
        {

            camera.SetActive(true);
            playerCamera.SetActive(false);
            inp.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Screen.lockCursor = false;

        }
    }

    public void checkCode()
    {
        InputField inputField = inp.GetComponent<InputField>();
        textCode = inputField.text;
        if(textCode == code)
        {
            ExitCode();
        }
        wrongCode();
    }

    public void ExitCode()
    {
        playerCamera.SetActive(true);
        camera.SetActive(false);

        this.transform.position = open.position;
        rb.isKinematic = true;
        Cursor.visible = false;
        Screen.lockCursor = true;
    }

    public void wrongCode()
    {
        playerCamera.SetActive(true);
        camera.SetActive(false);
        Cursor.visible = false;
        Screen.lockCursor = true;
    }

}