using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float m_fSpeedValue;
    [SerializeField] private float moveValue;
    [SerializeField] private float m_fJumpForce;

    // modifiable key placed in the editor (set as Space)
    [SerializeField] private KeyCode m_Jump;

    // checks if the player is grounded
    [SerializeField] private bool m_bCanJump;

    [SerializeField] 

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
        Vector3 m_vel = new Vector3(moveValue, 0.0f);
        m_rb.AddForce(m_vel, ForceMode.Force);
        //m_rb.velocity = new Vector3(moveValue * m_fSpeedValue, m_rb.velocity.y, 0); 
        
        if (Input.GetKeyDown(m_Jump) && m_bCanJump)
        {
            m_rb.AddForce(Vector3.up * m_fJumpForce, ForceMode.Impulse);
            m_bCanJump = false;
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            m_bCanJump = true;
        }
    }
}
