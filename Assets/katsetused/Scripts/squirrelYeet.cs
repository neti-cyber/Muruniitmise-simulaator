using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squirrelYeet : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioData;

    public float bounce = 600f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioData = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7) //grass layer = 6
        {
            audioData.Play(0);
            rb.AddForce(collision.contacts[0].normal * bounce);
        }
    }
}
