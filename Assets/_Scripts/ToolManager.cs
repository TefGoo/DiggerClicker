// ToolManager.cs
using TMPro;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public ToolScript[] tools; // Reference to all the tools
    public TMP_Text activeToolText; // Text to display the active tool

    public ToolScript activeTool; // Currently active tool

    private void Start()
    {
        SetActiveTool(tools[0]);
    }
    public string OnToolButtonClick(int toolIndex, int toolCost, EconomyScript economyScript)
    {
        if (toolIndex >= 0 && toolIndex < tools.Length)
        {
            // Check if the player has enough points to buy the tool
            int playerPoints = economyScript.GetPoints();

            if (playerPoints >= toolCost && !tools[toolIndex].IsUnlocked())
            {
                // Deduct the cost from player points
                economyScript.DeductPoints(toolCost);

                // Unlock the tool
                tools[toolIndex].Unlock();

                // Set the active tool
                SetActiveTool(tools[toolIndex]);

                return "Tool bought successfully!";
            }
            else
            {
                // Return a message indicating why the tool couldn't be bought
                if (tools[toolIndex].IsUnlocked())
                {
                    return "Tool is already unlocked.";
                }
                else
                {
                    return "Not enough points to buy this tool.";
                }
            }
        }

        return "Invalid tool index.";
    }


    private void SetActiveTool(ToolScript tool)
    {
        activeTool = tool;
        activeToolText.text = "Active Tool: " + activeTool.gameObject.name; // Update UI text
    }
}
