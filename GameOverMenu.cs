using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenuUI;

    void Start()
    {
        // Set the game over menu to inactive initially
        gameOverMenuUI.SetActive(false);
    }

    public void ShowGameOverMenu()
    {
        gameOverMenuUI.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    public void PlayAgain()
    {
        // Deactivate the game over menu UI
        gameOverMenuUI.SetActive(false);
        Time.timeScale = 1f; // Unpause the game

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoHome()
    {
        // Deactivate the game over menu UI
        gameOverMenuUI.SetActive(false);
        Time.timeScale = 1f; // Unpause the game

        // Load the main menu scene
        SceneManager.LoadScene("Main Menu"); // Replace "Main Menu" with your actual main menu scene name
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}


