using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject prefab; // The prefab to spawn
    public Transform[] spawnPoints; // Array of spawn points
    public int numberOfLayers = 4; // Number of layers to maintain
    public float timeBetweenSpawns = 5f; // Time between spawns in seconds
    public float delayToDeactivate = 4f; // Delay before deactivating objects

    private GameObject[] layers; // Array to hold the spawned layers
    private bool canSpawn = true; // Flag to control spawning
    private int spawnCounter = 0; // Counter to cycle through spawn points
    private bool initialSpawnPointsUsed = false; // Flag to track the initial spawn points usage

    void Start()
    {
        layers = new GameObject[numberOfLayers];
        InvokeRepeating("SpawnPrefab", 0f, timeBetweenSpawns);

        // Call the DeactivateObjects function after a delay
        Invoke("DeactivateObjects", delayToDeactivate);
    }

    void SpawnPrefab()
    {
        // Check if there are fewer than four active layers before spawning
        if (canSpawn && CountActiveLayers() < numberOfLayers)
        {
            // Spawn a new layer at the bottom
            for (int i = numberOfLayers - 1; i > 0; i--)
            {
                layers[i] = layers[i - 1];
            }

            Transform spawnPoint;

            if (!initialSpawnPointsUsed)
            {
                // Use the initial spawn points (1, 2, 3) only for the first time
                spawnPoint = spawnPoints[spawnCounter];
                spawnCounter = (spawnCounter + 1) % spawnPoints.Length;

                if (spawnCounter == 0)
                {
                    initialSpawnPointsUsed = true;
                }
            }
            else
            {
                // Use the bottom spawn point for subsequent spawns
                spawnPoint = spawnPoints[spawnPoints.Length - 1];
            }

            layers[0] = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        }
    }

    // Helper function to count the number of active layers
    int CountActiveLayers()
    {
        int count = 0;
        foreach (GameObject layer in layers)
        {
            if (layer != null)
            {
                count++;
            }
        }
        return count;
    }

    // Function to be called after a delay to deactivate specific objects
    void DeactivateObjects()
    {
        // Deactivate the specified objects
        foreach (Transform spawnPoint in spawnPoints)
        {
            spawnPoint.gameObject.SetActive(false);
        }
    }
}
