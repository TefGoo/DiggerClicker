using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject loadingPanel; // Reference to the loading panel
    public GameObject[] prefabs; // Array of prefabs to spawn
    public int[] prefabCounts; // Number of each prefab to spawn initially
    public int additionalPrefabsToSpawn = 8; // Number of additional prefabs to spawn when triggered
    public float prefabSpacing = 1f; // Spacing between prefabs

    private GameObject[] layers; // Array to hold the spawned layers
    private int currentPrefabIndex = 0; // Index to track the current prefab to spawn
    private float currentYOffset = 0f; // Y offset to track the position of the next prefab

    void Start()
    {
        ShowLoadingPanel();
        Invoke("SpawnInitialPrefabs", 0.4f);
        Invoke("HideLoadingPanel", 2f); // Delay the execution of HideLoadingPanel by 2 seconds
    }

    // Function to show the loading panel
    void ShowLoadingPanel()
    {
        if (loadingPanel != null)
        {
            loadingPanel.SetActive(true);
        }
    }

    // Function to hide the loading panel
    void HideLoadingPanel()
    {
        if (loadingPanel != null)
        {
            loadingPanel.SetActive(false);
        }
    }

    // Function to spawn the initial set of prefabs
    void SpawnInitialPrefabs()
    {
        SpawnPrefabs(prefabCounts);
    }

    // Function to be called when a prefab is destroyed
    public void OnPrefabDestroyed()
    {
        SpawnAdditionalPrefabs();
    }

    // Function to spawn additional prefabs when triggered by player actions
    void SpawnAdditionalPrefabs()
    {
        if (currentPrefabIndex < prefabs.Length)
        {
            int remainingPrefabs = Mathf.Min(prefabCounts[currentPrefabIndex], additionalPrefabsToSpawn);

            // Spawn additional prefabs
            while (remainingPrefabs > 0)
            {
                Vector3 spawnPosition = new Vector3(transform.position.x, currentYOffset, transform.position.z);
                layers[currentPrefabIndex] = Instantiate(prefabs[currentPrefabIndex % prefabs.Length], spawnPosition, Quaternion.identity);
                currentYOffset -= prefabSpacing; // Update the Y offset for the next prefab
                currentPrefabIndex++;
                remainingPrefabs--;

                if (currentPrefabIndex >= prefabs.Length)
                    break;
            }
        }
    }

    // Function to spawn prefabs based on the provided counts
    void SpawnPrefabs(int[] counts)
    {
        int totalPrefabCount = 0;

        // Calculate the total number of prefabs to spawn
        foreach (int count in counts)
        {
            totalPrefabCount += count;
        }

        layers = new GameObject[totalPrefabCount];
        int currentCountIndex = 0;

        // Spawn each prefab according to the specified counts
        for (int i = 0; i < prefabs.Length; i++)
        {
            for (int j = 0; j < counts[i]; j++)
            {
                Vector3 spawnPosition = new Vector3(transform.position.x, currentYOffset, transform.position.z);
                layers[currentCountIndex] = Instantiate(prefabs[i], spawnPosition, Quaternion.identity);
                currentYOffset -= prefabSpacing; // Update the Y offset for the next prefab
                currentCountIndex++;
            }
        }
    }
}
