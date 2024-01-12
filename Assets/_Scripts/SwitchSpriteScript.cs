using UnityEngine;
using UnityEngine.UI;

public class SwitchSpriteScript : MonoBehaviour
{
    public Image imageToSwitch; // Reference to the Image component you want to switch sprites
    public Sprite firstSprite;   // First sprite
    public Sprite secondSprite;  // Second sprite

    private bool isUsingFirstSprite = true;

    // Start is called before the first frame update
    void Start()
    {
        if (imageToSwitch == null)
        {
            Debug.LogError("Image to switch is not assigned in the inspector!");
        }
        else
        {
            // Set the initial sprite based on the initial state
            imageToSwitch.sprite = isUsingFirstSprite ? firstSprite : secondSprite;
        }
    }

    // Function to switch between sprites
    public void SwitchSprites()
    {
        // Toggle the state
        isUsingFirstSprite = !isUsingFirstSprite;

        // Switch the sprite based on the current state
        imageToSwitch.sprite = isUsingFirstSprite ? firstSprite : secondSprite;
    }
}
