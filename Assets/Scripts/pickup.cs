using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{

    public Transform destination;

    void OnMouseDown()
    {
        float dist = Vector3.Distance(this.transform.position, destination.position);
        if(dist < 5f)
        { 
            //GetComponent<SphereCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            //GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.transform.position = destination.position;

            this.transform.parent = GameObject.Find("destination").transform;
        }
    }

    void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        //GetComponent<SphereCollider>().enabled = true;
        //GetComponent<BoxCollider>().enabled = true;


    }

}

