using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour
{
    public void StartGame()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene("Level1");
    }

    public void ReturnHome()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void Restart()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}


