using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Function to start the game
    public void StartGame()
    {
        // Load the main game scene (you can replace "GameScene" with the actual name of your game scene)
        SceneManager.LoadScene("GameScreen");
    }

    // Function to load the credits scene
    public void LoadCredits()
    {
        // Load the credits scene (you can replace "CreditsScene" with the actual name of your credits scene)
        SceneManager.LoadScene("CreditsScreen");
    }

    // Function to load the title scene
    public void LoadTitle()
    {
        // Load the credits scene (you can replace "CreditsScene" with the actual name of your credits scene)
        SceneManager.LoadScene("TitleScreen");
    }

    // Function to close the game
    public void ExitGame()
    {
        // This will only work in a standalone build, not in the Unity Editor
        Application.Quit();
        Debug.Log("Closing game...");
    }
}
