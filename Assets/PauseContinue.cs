using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseContinue : MonoBehaviour
{
    public GameObject PausePanel;

    void Start()
    {
        PausePanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0f)
            {
                PausePanel.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                Time.timeScale = 0f;
                PausePanel.SetActive(true);
            }
        }
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    { 
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }

    public void Restart()
    { 
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        PausePanel.SetActive(false);
    }
}
