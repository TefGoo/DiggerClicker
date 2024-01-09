using TMPro;
using UnityEngine;

public class RemainingHPScript : MonoBehaviour
{
    public TextMeshPro hpText; // Reference to the TextMeshProUGUI component

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
    void Update()
    {
        // Continuously update the TextMeshPro with the remaining HP
        UpdateHPText();
    }

    void UpdateHPText()
    {
        // Update the TextMeshProUGUI with the remaining HP
        hpText.text = "Remaining HP: " + damageScript.GetCurrentHP();
    }
}
