using UnityEngine;

public class SpawnParticleSystem : MonoBehaviour
{
    public ParticleSystem particleSystemPrefab; // Reference to the particle system prefab

    public void OnButtonClick()
    {
        // Check if the particleSystemPrefab is assigned
        if (particleSystemPrefab != null)
        {
            // Instantiate the particle system at the button's position
            ParticleSystem instantiatedParticleSystem = Instantiate(particleSystemPrefab, transform.position, Quaternion.identity);

            // Play the particle system animation
            instantiatedParticleSystem.Play();
        }
        else
        {
            Debug.LogWarning("Particle system prefab is not assigned in the inspector.");
        }
    }
}
