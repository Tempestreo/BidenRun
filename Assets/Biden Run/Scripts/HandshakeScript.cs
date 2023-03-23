using UnityEngine;

public class HandshakeScript : MonoBehaviour
{
    VoteManager scVote;
    bool touch;

    void Start()
    {
        touch = false;
        scVote = FindObjectOfType<VoteManager>();
    }
    private void FixedUpdate()
    {
        if (scVote.gameObject.transform.position.z > this.gameObject.transform.position.z && touch == false)
        {
            scVote.MissHandShake();
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
