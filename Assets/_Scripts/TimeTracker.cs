using UnityEngine;
using TMPro;

public class TimeTracker : MonoBehaviour
{
    public TMP_Text timeText; // Reference to the TMP Text for displaying time
    private float elapsedTime; // Time elapsed since scene load
    private bool trackingTime = true; // Flag to control time tracking

    void Start()
    {
        // Reset and start tracking time on scene load
        elapsedTime = 0f;
        trackingTime = true;
    }

    void Update()
    {
        // Check if time tracking is enabled
        if (trackingTime)
        {
            // Update elapsed time
            elapsedTime += Time.deltaTime;

            // Display elapsed time in TMP Text
            if (timeText != null)
            {
                timeText.text = "You were digging for " + FormatTime(elapsedTime);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has entered the trigger collider
        if (other.CompareTag("Player"))
        {
            // Stop tracking time when the player enters the trigger
            trackingTime = false;
        }
    }

    // Helper method to format time in minutes and seconds
    string FormatTime(float seconds)
    {
        int minutes = Mathf.FloorToInt(seconds / 60f);
        int remainingSeconds = Mathf.FloorToInt(seconds % 60f);
        return string.Format("{0:00}:{1:00}", minutes, remainingSeconds);
    }
}
