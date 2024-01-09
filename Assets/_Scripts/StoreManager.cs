using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public ToolManager toolManager; // Reference to the ToolManager
    public TMP_Text pointsText; // Text to display player points
    public Button[] toolButtons; // Array of buttons representing each tool
    public int[] toolCosts; // Cost of each tool

    private void Start()
    {
        // Initialize player points from PlayerPrefs (you can modify this based on your saving mechanism)
        UpdatePointsUI();

        // Add click listeners to each tool button
        for (int i = 0; i < toolButtons.Length; i++)
        {
            int index = i; // Required to capture the correct index in the lambda expression
            int cost = toolCosts[i];
            toolButtons[i].onClick.AddListener(() => OnToolButtonClick(index, cost));
        }
    }

    // Called when a tool button is clicked
    private void OnToolButtonClick(int toolIndex, int toolCost)
    {
        toolManager.OnToolButtonClick(toolIndex, toolCost);
    }

    // Update UI with the current points
    private void UpdatePointsUI()
    {
        pointsText.text = "Points: " + PlayerPrefs.GetInt("PlayerPoints", 0).ToString();
    }
}
