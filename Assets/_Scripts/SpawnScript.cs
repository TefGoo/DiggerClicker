using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] prefabs; // Array of prefabs to spawn
    public Transform[] spawnPoints; // Array of spawn points
    public int numberOfLayers = 4; // Number of layers to maintain
    public float timeBetweenSpawns = 5f; // Time between spawns in seconds
    public float delayToDeactivate = 4f; // Delay before deactivating objects

    private GameObject[] layers; // Array to hold the spawned layers
    private bool canSpawn = true; // Flag to control spawning
    private int spawnCounter = 0; // Counter to cycle through spawn points
    private bool initialSpawnPointsUsed = false; // Flag to track the initial spawn points usage
    private int totalSpawnedPrefabs = 0; // Counter for total spawned prefabs

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
            int prefabIndex = ChoosePrefabIndex();

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

            layers[0] = Instantiate(prefabs[prefabIndex], spawnPoint.position, Quaternion.identity);
            totalSpawnedPrefabs++;

            LogPrefabInfo(prefabs[prefabIndex].name);
        }
    }

    int ChoosePrefabIndex()
    {
        // Return the index based on your spawning rules
        if (totalSpawnedPrefabs < 50)
        {
            return 0; // Spawn prefab 1
        }
        else if (totalSpawnedPrefabs < 175)
        {
            return 1; // Spawn prefab 2
        }
        else if (totalSpawnedPrefabs < 425)
        {
            return 2; // Spawn prefab 3
        }
        else if (totalSpawnedPrefabs < 1925)
        {
            return 3; // Spawn prefab 4
        }
        else if (totalSpawnedPrefabs < 6925)
        {
            return 4; // Spawn prefab 5
        }
        else if (totalSpawnedPrefabs < 26925)
        {
            return 5; // Spawn prefab 6
        }
        else if (totalSpawnedPrefabs < 76925)
        {
            return 6; // Spawn prefab 7
        }
        else
        {
            return 7; // Spawn prefab 8
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

    // Log prefab information to the console
    void LogPrefabInfo(string prefabName)
    {
        Debug.Log("Spawned prefab: " + prefabName);
    }
}
