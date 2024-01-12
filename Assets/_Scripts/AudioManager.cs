using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Singleton instance
    public static AudioManager Instance;

    // Reference to the music AudioSource
    public AudioSource musicSource;

    private bool isMuted = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Toggle mute state
    public void ToggleMute()
    {
        isMuted = !isMuted;

        // Implement your audio mute/unmute logic here
        if (isMuted)
        {
            MuteAudio();
        }
        else
        {
            UnmuteAudio();
        }
    }

    // Mute the music
    private void MuteAudio()
    {
        if (musicSource != null)
        {
            musicSource.volume = 0f;
        }
    }

    // Unmute the music
    private void UnmuteAudio()
    {
        if (musicSource != null)
        {
            musicSource.volume = .18f; // You can adjust the volume level as needed
        }
    }

    // Add other audio-related functions here
}
