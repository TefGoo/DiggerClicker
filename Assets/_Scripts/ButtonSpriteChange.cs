using UnityEngine;
using UnityEngine.UI;

public class ButtonSpriteChange : MonoBehaviour
{
    public Button yourButton; // Reference to your button
    public SpriteRenderer targetObject; // Reference to the object with SpriteRenderer
    public Sprite newSprite; // New sprite to show when the button is pressed

    private Sprite originalSprite;

    void Start()
    {
        // Check if a button and target object are assigned
        if (yourButton != null && targetObject != null)
        {
            // Save the original sprite
            originalSprite = targetObject.sprite;

            // Add a listener to the button click event
            yourButton.onClick.AddListener(ChangeSprite);
        }
        else
        {
            Debug.LogWarning("Button or targetObject not set in ButtonSpriteChange script!");
        }
    }

    void ChangeSprite()
    {
        // Check if a new sprite is assigned
        if (newSprite != null)
        {
            // Change to the new sprite
            targetObject.sprite = newSprite;

            // Invoke a method to reset to the original sprite after a short duration
            Invoke("ResetToOriginalSprite", 0.1f);
        }
        else
        {
            Debug.LogWarning("New sprite not set in ButtonSpriteChange script!");
        }
    }

    void ResetToOriginalSprite()
    {
        // Reset to the original sprite
        targetObject.sprite = originalSprite;
    }
}
