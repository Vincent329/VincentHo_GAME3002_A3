using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform target; // Target is the player

    [SerializeField] private float m_fTargetArmLength; // default value set to 15
    [SerializeField] private Vector3 m_TargetOffset; // set to 2 on the y in the inspector
    [SerializeField] private float m_fCameraLag = 0.25f;
    [SerializeField] private float m_fCameraLagMaxTimeStep = 1.0f / 60.0f;

    // values to store previous location vectors for interpolation lag
    private Vector3 m_vPrevDesiredLoc;
    private Vector3 m_vPrevArmOrigin;

    [SerializeField] private bool bLagEnabled;

    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        LocationUpdate(bLagEnabled, Time.deltaTime);
    }

    private void LocationUpdate(bool bDoLag, float fDeltaTime)
    {
        Vector3 ArmOrigin = target.position + m_TargetOffset;

        Vector3 DesiredLocation = ArmOrigin;

        if (bDoLag)
        {
            // introducing substepping, moving the camera based on lerping distance factored by timestep
            Vector3 ArmMovementStep = (DesiredLocation - m_vPrevDesiredLoc) * (1.0f / fDeltaTime);
            Vector3 LerpTarget = m_vPrevDesiredLoc;

            float remainingTime = fDeltaTime;
            while (remainingTime > Mathf.Epsilon)
            {
                // depending on your computer's frames, take the smallest timestep to move the camera along
                float LerpAmount = Mathf.Min(m_fCameraLagMaxTimeStep, remainingTime); 
                LerpTarget += ArmMovementStep * LerpAmount; 
                remainingTime -= LerpAmount; // this prevents an infinite loop

                DesiredLocation = Vector3.Lerp(m_vPrevDesiredLoc, LerpTarget, LerpAmount / m_fCameraLag);
                m_vPrevDesiredLoc = DesiredLocation;
            }
        }
  
        // saving the previous locations of the camera
        m_vPrevArmOrigin = ArmOrigin;
        m_vPrevDesiredLoc = DesiredLocation;

        // pushing back the location of the camera by the length of the arm
        DesiredLocation -= transform.forward * m_fTargetArmLength;

        transform.position = DesiredLocation;
    }

}
