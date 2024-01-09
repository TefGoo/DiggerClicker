using UnityEngine;

public class ToolScript : MonoBehaviour
{
    public string toolName;
    public int toolCost;
    public float damageMultiplier = 1f;

    private bool isUnlocked = false;

    public bool IsUnlocked()
    {
        return isUnlocked;
    }

    public void Unlock()
    {
        isUnlocked = true;
        // Add any additional logic for unlocking the tool
    }
}
