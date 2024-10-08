using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private bool _isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _isPaused == false)
        {
            panel.SetActive(true);
            _isPaused = true;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _isPaused == true)
        {
            panel.SetActive(false);
            _isPaused = false;
            Time.timeScale = 1;

        }
    }
    public void Play()
    {
        Time.timeScale = 1;
        _isPaused = false;
        panel.SetActive(false);
        
        
    }
}
