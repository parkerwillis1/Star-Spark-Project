using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public SceneLoader sceneLoader; // Reference to the SceneLoader script

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (pauseMenuUI.activeSelf)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f; // Unpause the game
        }
        else
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void LoadMainMenu()
    {
        pauseMenuUI.SetActive(false); // Deactivate the pause menu UI
        sceneLoader.LoadScene("Main Menu"); // Load the main menu scene
    }

    // Other methods like QuitGame can be added here


    public void QuitGame()
        {
            Debug.Log("Quitting game...");
            Application.Quit();
        }
}
