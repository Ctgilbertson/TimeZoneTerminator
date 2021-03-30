using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{

    public Transform destination;
    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;

    //void Update()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        mPosDelta = Input.mousePosition - mPrevPos;
    //        transform.Rotate(transform.up, -Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);
    //    }
    //    mPrevPos = Input.mousePosition;
    //}

    void OnMouseDown()
    {
        float dist = Vector3.Distance(this.transform.position, destination.position);

        //this.transform.Rotate(Vector3.up, 90.0f);
        mPosDelta = Input.mousePosition - mPrevPos;
        transform.Rotate(transform.up, -Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);
        //mPrevPos = Input.mousePosition;
        if (dist < 5f)
        { 
            //GetComponent<SphereCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            //GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;


            //this.transform.position = destination.position;
            //this.transform.Rotate(Vector3.forward * 20);

            this.transform.parent = GameObject.Find("destination").transform;
        }
    }

    //void Update()
    //{
    //    mPrevPos = Input.mousePosition;
    //}

    void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        //GetComponent<SphereCollider>().enabled = true;
        //GetComponent<BoxCollider>().enabled = true;
    }

}

