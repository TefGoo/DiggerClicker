using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int maxHP = 10; // Maximum HP of the prefab
    private int currentHP; // Current HP of the prefab

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
        }
    }
}