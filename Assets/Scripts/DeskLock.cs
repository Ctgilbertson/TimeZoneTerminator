using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskLock : MonoBehaviour
{

    public Transform destination;
    public GameObject uiObject;
    public GameObject camera;
    public GameObject playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        camera.SetActive(false);

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

        }
    }


    void OnMouseUp()
    {
        playerCamera.SetActive(true);
        camera.SetActive(false);

    }

}