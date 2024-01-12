using UnityEngine;

public class SpawnParticleSystem : MonoBehaviour
{
    public GameObject particlePrefab;  // Reference to the particle system prefab
    public Transform spawnPoint;       // The spawn point for the particle system

    public void SpawnParticles()
    {
        // Check if the particle prefab and spawn point are set
        if (particlePrefab != null && spawnPoint != null)
        {
            // Instantiate the particle system at the spawn point
            GameObject particleSystemInstance = Instantiate(particlePrefab, spawnPoint.position, Quaternion.identity);

            // Optionally, you can parent the particle system to keep things organized
            particleSystemInstance.transform.parent = spawnPoint;
        }
        else
        {
            Debug.LogWarning("Particle prefab or spawn point not set in the ParticleSpawner script.");
        }
    }
}