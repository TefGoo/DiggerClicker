using TMPro;
using UnityEngine;

public class RemainingHPScript : MonoBehaviour
{
    public TextMeshProUGUI hpText; // Reference to the TextMeshProUGUI component

    private DamageScript damageScript; // Reference to the DamageScript on the same GameObject

    void Start()
    {
        damageScript = GetComponent<DamageScript>();

        // Check if the DamageScript is attached
        if (damageScript != null && hpText != null)
        {
            UpdateHPText();
        }
        else
        {
            Debug.LogError("RemainingHPScript: DamageScript or hpText not assigned!");
        }
    }

    void UpdateHPText()
    {
        // Update the TextMeshProUGUI with the remaining HP
        hpText.text = "Remaining HP: " + damageScript.GetCurrentHP();
    }
}
