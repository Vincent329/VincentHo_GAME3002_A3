using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerScript : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] private float m_totalTime;
    [SerializeField] private float m_minutes;
    [SerializeField] private float m_seconds;

    [SerializeField] private TextMeshProUGUI textDisplay;

    private void Start()
    {
        TextToScreen();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        CheckTime();
        TextToScreen();
    }
    private void CheckTime()
    {
        m_totalTime -= Time.deltaTime; 

        m_minutes = (int)(m_totalTime / 60); // display total time in minutes
        m_seconds = (int)(m_totalTime % 60); // modulo factor of total time in 60 seconds

        if (m_totalTime <= 0.0f)
        {
            TimeExpired();
        }
    }
    public void TextToScreen()
    {
        if (m_seconds < 10)
        {
            textDisplay.text = "Time: " + m_minutes + ": 0" + m_seconds;
        }
        else
        {
            textDisplay.text = "Time: " + m_minutes + ": " + m_seconds;
        }
    }

    private void TimeExpired()
    {
        SceneManager.LoadScene("GameOver");
    }
}
