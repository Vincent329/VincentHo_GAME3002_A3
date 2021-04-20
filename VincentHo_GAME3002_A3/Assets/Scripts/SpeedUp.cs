using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;

        //rb.velocity *= 1.05f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.attachedRigidbody;
            Vector3 pushForce = rb.velocity * 1.5f;

            rb.AddForce(pushForce, ForceMode.Impulse);
        }
    }
}
