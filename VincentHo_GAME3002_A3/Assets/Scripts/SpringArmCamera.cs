using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringArmCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float smoothingSpeed;
    [SerializeField]
    private Vector3 offset;

    //[SerializeField]
    //private float m_fSpringConstant = 1800.0f;
    //[SerializeField]
    //private float m_fDampingConstant = 600.0f;
    //[SerializeField]
    //private float m_fMass = 50.0f;

    //[SerializeField]
    //private Vector3 m_vNewPos; // this is the updated position
    //private Vector3 m_vDeltaPos; // the change in position
    //private Vector3 m_vOldPos; // need?



    private void FixedUpdate()
    {
        FollowCharacter();   
    }

    private void FollowCharacter()
    {
        Vector3 vDesiredPos = target.position + offset;
        float smoothingFactor = smoothingSpeed * Time.deltaTime;
        Vector3 vSmoothingPos = Vector3.Lerp(transform.position, vDesiredPos, smoothingFactor);
        transform.position = vSmoothingPos;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(offset, 2.0f);
    }
}
