using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Button uiPauseButton; // Reference to the UI pause button

    private void Start()
    {
        // Ensure the UI pause button is not null
        if (uiPauseButton == null)
        {
            Debug.LogError("UI Pause Button not assigned in the inspector!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check for the "esc" key to toggle the pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    // Function to toggle the pause menu
    public void TogglePauseMenu()
    {
        // Toggle the visibility of the pause menu
        pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
        // Toggle the visibility of the UI pause button
        uiPauseButton.gameObject.SetActive(!pauseMenuUI.activeSelf);

    }

    // Function to resume the game
    public void ResumeGame()
    {
        // Hide the pause menu
        pauseMenuUI.SetActive(false);
        // Unhide the UI pause button
        uiPauseButton.gameObject.SetActive(true);
    }

    // Function to mute or unmute game sounds
    public void ToggleMute()
    {
        // Add your logic here to mute or unmute game sounds
        // You might want to use AudioManager or a similar system for managing audio
        // Example: AudioManager.Instance.ToggleMute();
    }

    // Function to return to the title screen
    public void ReturnToTitleScreen()
    {
        // Load the title screen scene (replace "TitleScreen" with the actual name of your title screen scene)
        SceneManager.LoadScene("TitleScreen");
    }

    // Function to exit the game
    public void ExitGame()
    {
        // This will only work in a standalone build, not in the Unity Editor
        Application.Quit();
        Debug.Log("Closing game...");
    }
}
