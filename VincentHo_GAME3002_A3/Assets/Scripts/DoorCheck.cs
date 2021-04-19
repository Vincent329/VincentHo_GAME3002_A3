using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCheck : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]
    private DoorScript m_Door; // getting the door tied to this check
    [SerializeField]
    private PlayerMovement m_Player; // to access the key value of the player

    [SerializeField]
    private bool m_IsInArea;

    void Start()
    {
        //m_Door = GetComponent<DoorScript>();
        m_IsInArea = false;
    }

    private void Update()
    {
        HandleDoorInputs();
    }

    private void OnTriggerEnter(Collider other)
    {
        m_IsInArea = true;
    }

    private void OnTriggerExit(Collider other)
    {
        m_IsInArea = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("TestOpen");
        }
    }

    private void HandleDoorInputs()
    {
        if (Input.GetKeyDown(KeyCode.E) && m_IsInArea)
        {
            m_Door.OpenDoor();
        }
    }
}
