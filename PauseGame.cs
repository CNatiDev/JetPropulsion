using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PauseGame : MonoBehaviour
{
    public  bool isPaused = false;
    public UnityEvent Event_Pause;
    public UnityEvent Event_Resume;
    // Update is called once per frame
    private void Start()
    {
        if (isPaused)
        {
            Time.timeScale = 0f; // Stop time
            Event_Pause.Invoke();
        }

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f; // Stop time
        Event_Pause.Invoke();
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f; // Resume time
        Event_Resume.Invoke();
    }
}
