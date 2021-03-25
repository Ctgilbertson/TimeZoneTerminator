using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Transform open;

    // ROtation 0,90,0
    //position -1.21, 1.13, -2.72
    public Collider key;
    // Start is called before the first frame update
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.name == "key")
        {
            this.transform.parent.position = open.position;
            this.transform.parent.rotation = open.rotation;

        }
    }
}
