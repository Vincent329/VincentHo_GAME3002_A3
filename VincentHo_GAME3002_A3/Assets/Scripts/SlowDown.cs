using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    [SerializeField]
    private float m_fSlowVariable;
    // Start is called before the first frame update
  
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.attachedRigidbody.velocity *= m_fSlowVariable;
        }
    }
}
