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
    [SerializeField] private int m_iKeyCount;

    [SerializeField] private Transform SpawnPoint;

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
        transform.position = SpawnPoint.position;
        m_iKeyCount = 0;
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

        // jump force
        if (Input.GetKeyDown(m_Jump) && m_bCanJump)
        {
            m_rb.AddForce(Vector3.up * m_fJumpForce, ForceMode.Impulse);

            m_bCanJump = false;
        }
    }
    private void FixedUpdate()
    {

        AddForceToVelocity(m_rb, m_vel, 5.0f);
    }

    // used to clamp the maximum velocity when adding 
    // rb = script's rigid body
    // maxVelocity = the threshold of speed that the rigid body can travel
    // AppForce = minimum amount of force applied to push the rigid body
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
        if (other.gameObject.tag == "Trap")
        {
            transform.position = SpawnPoint.transform.position;
            m_rb.velocity = Vector3.zero;
        }
        if (other.gameObject.tag == "Key")
        {
            Debug.Log("TestKey");
            m_iKeyCount++;
            Destroy(other.gameObject);
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DoorCheck")
        {
            Debug.Log("Key???");
            //if (Input.GetKeyDown(KeyCode.E))
            //{
            //    DoorScript doorCheck = other.gameObject.GetComponent<DoorScript>();
            //    doorCheck.OpenDoor();
            //    Debug.Log("OpenTest");
            //}
        }
    }

    public int GetKeyCount()
    {
        return m_iKeyCount;
    }
}
