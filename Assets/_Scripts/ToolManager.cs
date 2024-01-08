using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToolManager : MonoBehaviour
{
    public ToolScript[] tools; // Reference to all the tools
    public TMP_Text activeToolText; // Text to display the active tool

    private ToolScript activeTool; // Currently active tool

    void Start()
    {
        // Set the default active tool
        SetActiveTool(tools[0]);
    }

    // Called when a tool button is clicked
    public void OnToolButtonClick(int toolIndex)
    {
        if (toolIndex >= 0 && toolIndex < tools.Length)
        {
            SetActiveTool(tools[toolIndex]);
        }
    }

    // Set the active tool
    private void SetActiveTool(ToolScript tool)
    {
        activeTool = tool;
        activeToolText.text = "Active Tool: " + activeTool.gameObject.name; // Update UI text

        // Set the active tool in the MiningScript (replace with your actual MiningScript reference)
        MiningScript miningScript = FindObjectOfType<MiningScript>();
        if (miningScript != null)
        {
            miningScript.SetCurrentTool(activeTool);
        }
    }
}
