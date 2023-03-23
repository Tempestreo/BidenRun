using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.tag == "cat" || this.gameObject.tag == "poop" || this.gameObject.tag == "handshake" || this.gameObject.tag == "bike")
        {
            Destroy(this.gameObject, 7.5f);
        }
        else
        {
            Destroy(this.gameObject, 3f);
        }
    }
}
