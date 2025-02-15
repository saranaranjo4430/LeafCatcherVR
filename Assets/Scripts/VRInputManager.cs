using UnityEngine;
using UnityEngine.InputSystem;

public class VRInputManager : MonoBehaviour
{
    public MenuManager menuManager;         // Reference to the MenuManager script
    public InputActionReference pauseAction; // Input Action for pausing the game

    void Update()
    {
        if (pauseAction.action.triggered)
        {
            menuManager.PauseGame();
        }
    }
}
