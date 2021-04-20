using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class DoorScript : MonoBehaviour
{
    [SerializeField]
    private float m_fSpringConstant = 0.0f;
    [SerializeField]
    private float m_fPressedPosition = 0.0f;
    [SerializeField]
    private float m_fFlipperSpringDampen = 0.0f;

    // Door ID for every door
    [SerializeField]
    private int doorID;

    private HingeJoint m_hingeJoint = null;
    private JointSpring m_jointSpring;

    // Start is called before the first frame update
    void Start()
    {
        m_hingeJoint = GetComponent<HingeJoint>();
        m_hingeJoint.useSpring = true;

        m_jointSpring = new JointSpring();
        m_jointSpring.spring = m_fSpringConstant;
        m_jointSpring.damper = m_fFlipperSpringDampen;

        m_hingeJoint.spring = m_jointSpring;
    }

    // to call into the door check script
    public int GetDoorID()
    {
        return doorID;
    }

    public void OpenDoor()
    {
        m_jointSpring.targetPosition = m_fPressedPosition;
        m_hingeJoint.spring = m_jointSpring;
    }
}
