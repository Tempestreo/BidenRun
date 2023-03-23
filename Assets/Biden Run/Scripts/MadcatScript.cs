using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadcatScript : MonoBehaviour
{
    VoteManager scVote;
    bool touch;
    // Start is called before the first frame update
    void Start()
    {
        touch = false;
        scVote = FindObjectOfType<VoteManager>();
    }
    private void FixedUpdate()
    {
        //petting checker
        if (scVote.gameObject.transform.position.z > this.gameObject.transform.position.z && touch == false)
        {
            scVote.MissCatPetting();
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            touch = true;
        }
    }
}
