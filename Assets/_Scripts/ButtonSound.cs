using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public Button yourButton; // Reference to your button
    public AudioClip soundEffect; // Reference to your sound effect

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Check if a button is assigned
        if (yourButton != null)
        {
            // Add a listener to the button click event
            yourButton.onClick.AddListener(PlaySound);
        }
        else
        {
            Debug.LogWarning("Button reference not set in ButtonSound script!");
        }
    }

    void PlaySound()
    {
        // Check if a sound effect is assigned
        if (soundEffect != null && audioSource != null)
        {
            // Play the sound effect
            audioSource.PlayOneShot(soundEffect);
        }
        else
        {
            Debug.LogWarning("Sound effect or AudioSource not set in ButtonSound script!");
        }
    }
}
