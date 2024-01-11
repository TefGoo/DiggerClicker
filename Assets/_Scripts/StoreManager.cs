using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public ToolManager toolManager; // Reference to the ToolManager
    public EconomyScript economyScript; // Reference to the EconomyScript
    public TMP_Text pointsText; // Text to display player points
    public Button[] toolButtons; // Array of buttons representing each tool
    public int[] toolCosts; // Cost of each tool
    public TMP_Text messageText; // Text to display messages

    private void Start()
    {
        // Initialize player points from EconomyScript
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
        string message = toolManager.OnToolButtonClick(toolIndex, toolCost, economyScript);

        // Display the message in the TMP text field
        messageText.text = message;

        // Clear the message after a certain duration
        Invoke("ClearMessage", 3f);
    }

    // Update UI with the current points
    private void UpdatePointsUI()
    {
        pointsText.text = "Points: " + economyScript.GetPoints().ToString();
    }

    // Clear the message
    private void ClearMessage()
    {
        messageText.text = "";
    }
}
