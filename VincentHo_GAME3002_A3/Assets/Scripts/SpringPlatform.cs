using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlatform : MonoBehaviour
{

    [SerializeField]
    private float m_fSpringConstant;    
    [SerializeField]
    private float m_fDampingConstant;
    [SerializeField]
    private Vector3 m_vRest;  
    [SerializeField]
    private float m_fMass;
    [SerializeField]
    private Rigidbody m_AttachedObject = null;

    private Vector3 m_vForce;
    private Vector3 m_vPrevVelocity;

    // Start is called before the first frame update
    void Start()
    {
        m_fMass = m_AttachedObject.mass;
        m_fSpringConstant = CalculateSpringConstant();
        m_vRest.x = transform.position.x;
        m_vRest.z = transform.position.z;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        UpdateSpringForce();
    }

    private float CalculateSpringConstant()
    {
        float fDisplacement = (m_vRest - m_AttachedObject.transform.position).magnitude;

        if (fDisplacement <= 0)
        {
            return Mathf.Epsilon;
        }

        return (m_fMass * Physics.gravity.y) / fDisplacement;
    }

    private void UpdateSpringForce()
    {
        Vector3 vDisplacement = m_vRest - m_AttachedObject.transform.position;
        Vector3 vDeltaVel = m_AttachedObject.velocity - m_vPrevVelocity;

        // F = -kx - bv
        // k is spring constnat
        // x is displacement between 
        // b is damping constant
        // v is the change in velocity
        m_vForce = -m_fSpringConstant * vDisplacement
            - m_fDampingConstant * vDeltaVel;

        m_AttachedObject.AddForce(m_vForce, ForceMode.Acceleration);

        m_vPrevVelocity = m_AttachedObject.velocity;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(m_vRest, 1f);

        if (m_AttachedObject)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(m_AttachedObject.transform.position, 1f);

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, m_AttachedObject.transform.position);
        }
    }

}
