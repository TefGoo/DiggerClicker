using TMPro;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public ToolScript[] tools; // Reference to all the tools
    public TMP_Text activeToolText; // Text to display the active tool

    public ToolScript activeTool; // Currently active tool

    private void Start()
    {
        // Set the default active tool
        SetActiveTool(tools[0]);
    }

    // Called when a tool button is clicked
    public void OnToolButtonClick(int toolIndex, int toolCost)
    {
        if (toolIndex >= 0 && toolIndex < tools.Length)
        {
            // Check if the player has enough points to buy the tool
            int playerPoints = PlayerPrefs.GetInt("PlayerPoints", 0);

            if (playerPoints >= toolCost && !tools[toolIndex].IsUnlocked())
            {
                // Deduct the cost from player points
                playerPoints -= toolCost;
                PlayerPrefs.SetInt("PlayerPoints", playerPoints);

                // Save the updated points
                PlayerPrefs.Save();

                // Unlock the tool
                tools[toolIndex].Unlock();

                // Set the active tool
                SetActiveTool(tools[toolIndex]);
            }
            else
            {
                // Display a message or handle the case where the player doesn't have enough points
                Debug.Log("Not enough points to buy this tool or the tool is already unlocked.");
            }
        }
    }

    // Set the active tool
    private void SetActiveTool(ToolScript tool)
    {
        activeTool = tool;
        activeToolText.text = "Active Tool: " + activeTool.gameObject.name; // Update UI text
    }
}
