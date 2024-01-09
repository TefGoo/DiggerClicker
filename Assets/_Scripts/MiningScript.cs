using UnityEngine;
using UnityEngine.UI;

public class MiningScript : MonoBehaviour
{
    public Button mineButton; // Reference to the UI mine button
    public ToolManager toolManager; // Reference to the ToolManager

    private void Start()
    {
        mineButton.onClick.AddListener(MineButtonClick);
    }

    private void MineButtonClick()
    {
        // Check if the player is in contact with a mineable object
        GameObject mineableObject = GetMineableObject();
        if (mineableObject != null)
        {
            // Apply damage to the mineable object with the current tool's damage multiplier
            mineableObject.GetComponent<DamageScript>().TakeDamage(Mathf.RoundToInt(toolManager.activeTool.damageMultiplier));
        }
    }

    private GameObject GetMineableObject()
    {
        // Perform a 2D raycast to check what the player is in contact with
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null && hit.collider.gameObject.CompareTag("Mineable"))
        {
            return hit.collider.gameObject;
        }

        return null;
    }
}
