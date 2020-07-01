using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    private void Start()
    {
        Resume();
    }

    void Update()
    {
        // Escape is the input to turn on the pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    // Sets the pauseMenuUI to on, Freezes Game.
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    // Sets the pauseMenuUI to off, Unfreezes Game
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    // apply to Button "Loads Scene in the Hierachy With the name of "MainMenu""
    public void BackMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Menu");
    }

    // apply to a button "Player closes application"
    public void QuitMenu()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}
