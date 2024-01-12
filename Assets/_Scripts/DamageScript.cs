using System.Collections;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int maxHP = 10; // Maximum HP of the prefab
    private int currentHP; // Current HP of the prefab

    public int pointsOnDestroy = 10; // Default points to give when destroyed
    public EconomyScript economyScript; // Reference to the EconomyScript

    private CameraShake cameraShake; // Reference to the CameraShake script

    void Start()
    {
        currentHP = maxHP;

        // Get the CameraShake script attached to the main camera
        cameraShake = Camera.main.GetComponent<CameraShake>();
        if (cameraShake == null)
        {
            Debug.LogWarning("CameraShake script not found on the main camera.");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        // Check if the prefab's HP is below or equal to 0
        if (currentHP <= 0)
        {
            StartCoroutine(TriggerCameraShake()); // Start the camera shake coroutine
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

    IEnumerator TriggerCameraShake()
    {
        if (cameraShake != null)
        {
            cameraShake.ShakeCameraAndDisableVirtualCamera(); // Trigger camera shake
            yield return new WaitForSeconds(cameraShake.ShakeTime); // Wait for the shake duration
            cameraShake.StopShakeAndDisableVirtualCamera(); // Stop the camera shake
        }
    }

    public int GetCurrentHP()
    {
        return currentHP;
    }
}
