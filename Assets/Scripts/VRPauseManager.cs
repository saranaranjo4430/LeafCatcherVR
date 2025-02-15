using UnityEngine;
using UnityEngine.InputSystem;

public class VRPauseManager : MonoBehaviour
{
    private PlayerInputActions inputActions; // Reference to the Input Actions
    public MenuManager menuManager;         // Reference to the MenuManager

    void Awake()
    {
        // Initialize the input actions
        inputActions = new PlayerInputActions();

        // Bind the PauseGame action to a method
        inputActions.Menu.PauseGame.performed += _ => OnPauseGame();
    }

    void OnEnable()
    {
        // Enable the input actions
        inputActions.Enable();
    }

    void OnDisable()
    {
        // Disable the input actions
        inputActions.Disable();
    }

    void OnPauseGame()
    {
        if (menuManager != null)
        {
            // Check if the game is already paused
            if (Time.timeScale == 1f)
            {
                menuManager.PauseGame(); // Pause the game
            }
            else
            {
                menuManager.ResumeGame(); // Resume the game
            }
        }
        else
        {
            Debug.LogWarning("MenuManager reference is missing!");
        }
    }
}
