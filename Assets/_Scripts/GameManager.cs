using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Example variables to save
    private int playerScore;
    private Vector3 playerPosition;
    private int[] destroyedPrefabs;
    private SpawnedPrefabInfo[] spawnedPrefabs;

    [System.Serializable]
    public class SpawnedPrefabInfo
    {
        public int prefabType;
        public Vector3 position;
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        LoadPlayerProgress();
        SpawnSavedPrefabs();
    }

    void OnApplicationQuit()
    {
        SavePlayerProgress();
    }

    public void SavePlayerProgress()
    {
        // Save relevant information using PlayerPrefs
        PlayerPrefs.SetInt("PlayerScore", playerScore);
        PlayerPrefs.SetFloat("PlayerPositionX", playerPosition.x);
        PlayerPrefs.SetFloat("PlayerPositionY", playerPosition.y);
        PlayerPrefs.SetInt("DestroyedPrefabCount", destroyedPrefabs.Length);

        for (int i = 0; i < destroyedPrefabs.Length; i++)
        {
            PlayerPrefs.SetInt("DestroyedPrefab_" + i, destroyedPrefabs[i]);
        }

        PlayerPrefs.SetInt("SpawnedPrefabCount", spawnedPrefabs.Length);

        for (int i = 0; i < spawnedPrefabs.Length; i++)
        {
            PlayerPrefs.SetInt("SpawnedPrefabType_" + i, spawnedPrefabs[i].prefabType);
            PlayerPrefs.SetFloat("SpawnedPrefabPositionX_" + i, spawnedPrefabs[i].position.x);
            PlayerPrefs.SetFloat("SpawnedPrefabPositionY_" + i, spawnedPrefabs[i].position.y);
        }

        PlayerPrefs.Save();
    }

    public void LoadPlayerProgress()
    {
        // Load relevant information from PlayerPrefs
        playerScore = PlayerPrefs.GetInt("PlayerScore", 0);
        float posX = PlayerPrefs.GetFloat("PlayerPositionX", 0f);
        float posY = PlayerPrefs.GetFloat("PlayerPositionY", 0f);
        playerPosition = new Vector3(posX, posY, 0f);

        int destroyedPrefabCount = PlayerPrefs.GetInt("DestroyedPrefabCount", 0);
        destroyedPrefabs = new int[destroyedPrefabCount];

        for (int i = 0; i < destroyedPrefabCount; i++)
        {
            destroyedPrefabs[i] = PlayerPrefs.GetInt("DestroyedPrefab_" + i, 0);
        }

        int spawnedPrefabCount = PlayerPrefs.GetInt("SpawnedPrefabCount", 0);
        spawnedPrefabs = new SpawnedPrefabInfo[spawnedPrefabCount];

        for (int i = 0; i < spawnedPrefabCount; i++)
        {
            spawnedPrefabs[i] = new SpawnedPrefabInfo();
            spawnedPrefabs[i].prefabType = PlayerPrefs.GetInt("SpawnedPrefabType_" + i, 0);
            float spawnPosX = PlayerPrefs.GetFloat("SpawnedPrefabPositionX_" + i, 0f);
            float spawnPosY = PlayerPrefs.GetFloat("SpawnedPrefabPositionY_" + i, 0f);
            spawnedPrefabs[i].position = new Vector3(spawnPosX, spawnPosY, 0f);
        }
    }

    void SpawnSavedPrefabs()
    {
        foreach (SpawnedPrefabInfo spawnedPrefab in spawnedPrefabs)
        {
            // You need to implement a function to spawn prefabs based on the saved information
            // Example: SpawnPrefab(spawnedPrefab.prefabType, spawnedPrefab.position);
        }
    }
}