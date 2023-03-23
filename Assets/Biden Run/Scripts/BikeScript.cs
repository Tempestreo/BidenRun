using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeScript : MonoBehaviour
{
    Rigidbody rb;
    //bike's movement
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (this.transform.position.x > 0)
        {
            rb.velocity = new Vector3(-0.3f,0,0);
        }
        else
        {
            rb.velocity = new Vector3(0.3f, 0, 0);
        }
    }
}
