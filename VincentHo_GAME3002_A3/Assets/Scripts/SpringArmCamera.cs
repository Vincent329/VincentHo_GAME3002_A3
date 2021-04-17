using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringArmCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Camera m_SpringCamera = Camera.main;

    [SerializeField]
    private float m_fSpringConstant = 150.0f;
    [SerializeField]
    private float m_fDampingConstant = 60.0f;

    [SerializeField]
    private Vector3 m_vNewPos; // this is the updated position
    private Vector3 m_vDeltaPos; // the change in position
    private Vector3 m_vOldPos; // need?

    private Vector3 m_vRelativeVelocity;

    public float smoothingSpeed = 0.125f;

    void Start()
    {
        m_vNewPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void LateUpdate()
    {
    }
}
