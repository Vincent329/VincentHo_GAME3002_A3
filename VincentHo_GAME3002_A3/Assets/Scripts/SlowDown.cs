using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    [SerializeField]
    private float m_fSlowVariable; // factor of 0.8 in the inspector
  
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.attachedRigidbody.velocity *= m_fSlowVariable;
        }
    }
}
