using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{

    public Transform destination;
    public GameObject uiObject;
    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;

    //void Update()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        print("test mouse down");
    //        OnMouseDown1();
    //    }
    //    mPrevPos = Input.mousePosition;
    //}

    void Start()
    {
        uiObject.SetActive(false);
    }

    void OnMouseDown()
    {
        float dist = Vector3.Distance(this.transform.position, destination.position);

        //this.transform.Rotate(Vector3.up, 90.0f);
        mPosDelta = Input.mousePosition - mPrevPos;
        transform.Rotate(transform.up, -Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);

        if (dist < 5f)
        {
            GetComponent<Collider>().enabled = false;
            this.transform.parent = GameObject.Find("destination").transform;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().freezeRotation = true;

            uiObject.SetActive(true);


        }
    }

    void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Collider>().enabled = true;
        GetComponent<Rigidbody>().freezeRotation = false;

        uiObject.SetActive(false);

    }

}

