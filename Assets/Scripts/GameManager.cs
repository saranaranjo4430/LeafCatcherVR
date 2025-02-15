using UnityEngine;
using TMPro; // Import the TextMeshPro namespace

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro Score UI
    public int score = 0;  // The player's score

    // Method to update the score and UI
    public void AddToScore(int amount)
    {
        score += amount; // Increase the score
        scoreText.text = "Score: " + score; // Update the UI text
    }

    public void ResetScore()
    {
        Debug.Log("Resetting Score..."); // Debug log to check if this runs
        score = 0; // Reset score to 0
        scoreText.text = "Score: 0"; // Update UI
    }

}
