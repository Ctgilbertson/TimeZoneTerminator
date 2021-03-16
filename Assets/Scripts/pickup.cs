using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{

    public Transform destination;

    void OnMouseDown()
    {
        //GetComponent<SphereCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        //GetComponent<BoxCollider>().enabled = false;

        this.transform.position = destination.position;

        this.transform.parent = GameObject.Find("destination").transform;
    }

    void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        //GetComponent<SphereCollider>().enabled = true;
        //GetComponent<BoxCollider>().enabled = true;


    }

}

