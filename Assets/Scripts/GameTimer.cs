using UnityEngine;
using TMPro; // Import TextMeshPro

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to the TimerText UI
    public float gameDuration = 60f; // Game duration in seconds
    private float timeLeft;          // Tracks the remaining time
    private bool gameEnded = false;  // Tracks whether the timer has ended

    public GameObject gameOverCanvas; // Reference to GameOverCanvas
    public TextMeshProUGUI gameOverScoreText; // Reference to score text in GameOverCanvas
    public LeafSpawner leafSpawner; // Reference to the LeafSpawner
    public GameManager gameManager; // Reference to the GameManager for score

    void Start()
    {
        // Initialize the timer
        timeLeft = gameDuration;
        UpdateTimerUI();
        gameOverCanvas.SetActive(false); // Ensure Game Over screen is hidden at start
    }

    void Update()
    {
        if (!gameEnded)
        {
            // Decrease the remaining time
            timeLeft -= Time.deltaTime;

            // Check if the timer has run out
            if (timeLeft <= 0)
            {
                timeLeft = 0; // Clamp the time to 0
                gameEnded = true; // Mark the game as ended
                EndGame();
            }

            // Update the timer UI
            UpdateTimerUI();
        }
    }

    void UpdateTimerUI()
    {
        // Update the TimerText to show the remaining time
        timerText.text = "Time: " + Mathf.CeilToInt(timeLeft).ToString();
    }

    void EndGame()
    {
        Debug.Log("Game Over! Final Score: " + gameManager.score);

        // Stop spawning leaves
        if (leafSpawner != null)
        {
            leafSpawner.enabled = false; // Disable the leaf spawner
        }

        // Show the Game Over screen
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
        }

        // Update the final score on the Game Over screen
        if (gameOverScoreText != null)
        {
            gameOverScoreText.text = "Final Score: " + gameManager.score;
        }

        // Stop the game time
        Time.timeScale = 0f;
    }

    public void ResetTimer()
    {
        Debug.Log("Resetting Timer..."); // Debug log to check if this runs
        timeLeft = gameDuration; // Reset to 60 seconds
        gameEnded = false; // Reset game over flag
        UpdateTimerUI(); // Update UI immediately
    }


}
