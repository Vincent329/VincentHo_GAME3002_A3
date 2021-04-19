using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TorqueTrap : MonoBehaviour
{

    [SerializeField]
    private Vector3 m_vTorqueForce = Vector3.zero;
    [SerializeField]
    private Vector3 m_vCenterOfMass = Vector3.zero;
    [SerializeField]
    private Vector3 m_vForcePoint = Vector3.zero;
    [SerializeField]
    private float m_fMaxAngularVelocity;


    private Vector3 m_vTorque = Vector3.zero;
    private Rigidbody m_rb = null;


    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_rb.maxAngularVelocity = m_fMaxAngularVelocity;
    }

    private void FixedUpdate()
    {
        m_vTorque = Vector3.Cross(m_vTorqueForce, m_vForcePoint - m_vCenterOfMass);
        m_rb.AddTorque(m_vTorque);
    }
    // Update is called once per frame
    //void Update()
    //{

    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        // want to see how the forces are actually applied, so that when we're working on it in the editor, it's easier to see
        Gizmos.DrawWireSphere(transform.TransformPoint(m_vCenterOfMass), 0.1f);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.TransformPoint(m_vForcePoint), 0.1f);
    }

  
}
