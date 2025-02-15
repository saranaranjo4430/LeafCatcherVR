using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuCanvas;       // Reference to the Main Menu Canvas
    public GameObject instructionsPanel;   // Reference to the Instructions Panel
    public GameObject pauseMenuCanvas;     // Reference to the Pause Menu Canvas
    public GameObject scoreAndTimerCanvas; // Reference to the Score and Timer Canvas
    public GameObject gameOverCanvas;

    public LeafSpawner leafSpawner;        // Reference to the LeafSpawner
    public GameTimer gameTimer;            // Reference to the GameTimer
    public GameManager gameManager;

    private bool isPaused = false;

    void Start()
    {
        // Show the main menu at the start
        mainMenuCanvas.SetActive(true);
        scoreAndTimerCanvas.SetActive(false);
        pauseMenuCanvas.SetActive(false);

        // Pause the game at the start
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        Debug.Log("Start Button Clicked!");

        // Hide the main menu
        if (mainMenuCanvas != null)
        {
            mainMenuCanvas.SetActive(false);
        }

        // Show the score and timer UI
        if (scoreAndTimerCanvas != null)
        {
            scoreAndTimerCanvas.SetActive(true);
        }

        // Start the game
        gameManager.ResetScore();

        Time.timeScale = 1f;
        if (leafSpawner != null)
        {
            leafSpawner.enabled = true; // Enable leaf spawning
        }
        if (gameTimer != null)
        {
            gameTimer.ResetTimer(); // Reset the timer before starting
            gameTimer.enabled = true; // Start the timer
        }
    }


    public void ShowInstructions()
    {
        Debug.Log("Instructions Button Clicked!");

        if (instructionsPanel != null)
        {
            instructionsPanel.SetActive(true); // Show instructions
        }

        if (mainMenuCanvas != null)
        {
            mainMenuCanvas.SetActive(false); // Hide main menu
        }
    }

    public void BackToMainMenu()
    {
        Debug.Log("Back Button Clicked!");

        if (instructionsPanel != null)
        {
            instructionsPanel.SetActive(false); // Hide instructions
        }

        if (mainMenuCanvas != null)
        {
            mainMenuCanvas.SetActive(true); // Show main menu
        }
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            isPaused = true;

            // Show the pause menu and stop the game
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
            leafSpawner.enabled = false; // Disable leaf spawning
        }
    }

    public void ResumeGame()
    {
        if (isPaused)
        {
            isPaused = false;

            // Hide the pause menu and resume the game
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
            leafSpawner.enabled = true; // Enable leaf spawning
        }
    }

    public void QuitToMainMenu()
    {
        // Reset the game state and go back to the main menu
        isPaused = false;
        pauseMenuCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
        scoreAndTimerCanvas.SetActive(false);

        // Reset the timer and leaves
        Time.timeScale = 0f;
        gameTimer.enabled = false;
        leafSpawner.enabled = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit(); // Closes the application
    }

    public void ReturnToMainMenu()
    {
        Debug.Log("Returning to Main Menu...");

        // Hide the Game Over screen
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(false);
        }

        // Show the main menu
        if (mainMenuCanvas != null)
        {
            mainMenuCanvas.SetActive(true);
        }

        // Hide the score and timer UI
        if (scoreAndTimerCanvas != null)
        {
            scoreAndTimerCanvas.SetActive(false);
        }

        // Reset Game Variables
        Time.timeScale = 1f;
        gameTimer.enabled = false;
        leafSpawner.enabled = false;

        // Reset Score
        gameManager.ResetScore();

        // Reset Timer
        gameTimer.ResetTimer();

        // Clear all leaves from the scene
        ClearAllLeaves();
    }


    void ClearAllLeaves()
    {
        // Find all objects tagged as "Leaf" and destroy them
        GameObject[] leaves = GameObject.FindGameObjectsWithTag("Leaf");
        foreach (GameObject leaf in leaves)
        {
            Destroy(leaf);
        }
    }


}
