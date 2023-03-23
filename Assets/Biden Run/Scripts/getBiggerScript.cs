using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getBiggerScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DoBigger());
    }
    //menu animation with numerator
    IEnumerator DoBigger()
    {
        this.gameObject.transform.localScale = new Vector3(0.4f,0.4f,0.4f);
        for (Vector3 i = new Vector3 (0.4f,0.4f,0.4f); i.x <= 1.2f; i += new Vector3(0.05f,0.05f,0.05f))
        {
            this.gameObject.transform.localScale = i;
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }
}
