using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorCheck : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]
    private DoorScript m_Door; // getting the door tied to this check
    [SerializeField]
    private PlayerMovement m_Player; // to access the key value of the player

    [SerializeField] private TextMeshProUGUI KeyText;
    [SerializeField]
    private bool m_IsInArea;

    void Start()
    {
        //m_Door = GetComponent<DoorScript>();
        m_IsInArea = false;
        KeyText.text = "";
    }

    private void Update()
    {
        HandleDoorInputs();
    }

    private void OnTriggerEnter(Collider other)
    {
        m_IsInArea = true;
        if (m_Player.GetKeyCount() != m_Door.GetDoorID())
        {
            KeyText.text = "Key not found yet";
        } else
        {
            KeyText.text = "Press E to Open Door";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        m_IsInArea = false;
        KeyText.text = "";
    }

    private void HandleDoorInputs()
    {
        if (Input.GetKeyDown(KeyCode.E) && m_IsInArea)
        {
            if (m_Player.GetKeyCount() == m_Door.GetDoorID())
            {
                m_Door.OpenDoor();
                Destroy(gameObject);
                KeyText.text = "";
            } 
        }
    }
}
