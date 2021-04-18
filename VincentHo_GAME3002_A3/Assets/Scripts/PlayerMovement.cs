using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float m_fSpeedValue;
    [SerializeField] private float moveValue;
    [SerializeField] private float m_fJumpForce;
    [SerializeField] private Vector3 m_vel;

    [SerializeField] private float m_fMonitorSpeed;

    // modifiable key placed in the editor (set as Space)
    [SerializeField] private KeyCode m_Jump;

    // checks if the player is grounded
    [SerializeField] private bool m_bCanJump;

    private Rigidbody m_rb;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_bCanJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInputs();
    }

    private void HandleInputs()
    {
        moveValue = Input.GetAxisRaw("Horizontal");
        m_vel = new Vector3(moveValue * m_fSpeedValue, 0.0f, 0.0f);
        //m_rb.AddForce(m_vel, ForceMode.VelocityChange);

        if (Input.GetKeyDown(m_Jump) && m_bCanJump)
        {
            m_rb.AddForce(Vector3.up * m_fJumpForce, ForceMode.Impulse);

            m_bCanJump = false;
        }
    }

    private void FixedUpdate()
    {
        //if (m_rb.velocity.magnitude > m_fSpeedValue)
        //{
        //    m_rb.velocity *= 0.75f;
        //}
        AddForceToVelocity(m_rb, m_vel, 5.0f);
    }

    private void AddForceToVelocity(Rigidbody rb, Vector3 maxVelocity, float AppForce = 1, ForceMode mode = ForceMode.Force)
    {
        if (AppForce == 0 || maxVelocity.magnitude == 0)
            return;

        maxVelocity = maxVelocity + maxVelocity.normalized * 0.2f * rb.drag;

        // this could be any value really
        AppForce = Mathf.Clamp(AppForce, -rb.mass/Time.fixedDeltaTime, rb.mass/Time.fixedDeltaTime);

        if (rb.velocity.magnitude == 0)
        {
            rb.AddForce(maxVelocity * AppForce, mode);
        } else
        {
            Vector3 velocityProjectedToTarget = (maxVelocity.normalized * Vector3.Dot(maxVelocity, rb.velocity) / maxVelocity.magnitude);
            rb.AddForce((maxVelocity - velocityProjectedToTarget) * AppForce, mode);
        }
    }
    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            m_bCanJump = true;
        }
    }
}
