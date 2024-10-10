using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private bool _isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
               Continue();
            }
            else
            {
               PauseGame();
            }
        }
    }
    public void Continue()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
        _isPaused = false;
        Debug.Log("continue");
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void PauseGame()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
        _isPaused = true;
        Debug.Log("pause");
        Cursor.lockState = CursorLockMode.None;
    }
}
