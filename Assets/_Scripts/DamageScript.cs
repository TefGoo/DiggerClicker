using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int maxHP = 10; // Maximum HP of the prefab
    private int currentHP; // Current HP of the prefab

    public int pointsOnDestroy = 10; // Default points to give when destroyed
    public EconomyScript economyScript; // Reference to the EconomyScript

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        // Check if the prefab's HP is below or equal to 0
        if (currentHP <= 0)
        {
            Destroy(gameObject); // Destroy the topmost layer

            // Add points to the player's economy based on pointsOnDestroy
            if (economyScript != null)
            {
                economyScript.AddPoints(pointsOnDestroy);
                Debug.Log("Points added: " + pointsOnDestroy);
            }
            else
            {
                Debug.LogWarning("EconomyScript not assigned in DamageScript.");
            }
        }
    }
}
