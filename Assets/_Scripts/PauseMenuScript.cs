using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Button uiPauseButton;

    private void Start()
    {
        if (uiPauseButton == null)
        {
            Debug.LogError("UI Pause Button not assigned in the inspector!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
        uiPauseButton.gameObject.SetActive(!pauseMenuUI.activeSelf);
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        uiPauseButton.gameObject.SetActive(true);
    }

    public void ToggleMute()
    {
        AudioManager.Instance.ToggleMute();
    }

    public void ReturnToTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Closing game...");
    }
}
