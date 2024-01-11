using System.Collections;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    public GameObject[] gameObjects; // Array of GameObjects to cycle through
    public float delayBetweenObjects = 0.2f; // Delay between switching GameObjects

    private int currentGameObjectIndex = 0;

    void Start()
    {
        // Start the GameObject animation coroutine
        StartCoroutine(AnimateGameObjects());
    }

    IEnumerator AnimateGameObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayBetweenObjects);

            // Enable the next GameObject and disable the previous one
            ToggleGameObject(currentGameObjectIndex, false);
            currentGameObjectIndex = (currentGameObjectIndex + 1) % gameObjects.Length;
            ToggleGameObject(currentGameObjectIndex, true);
        }
    }

    void ToggleGameObject(int index, bool state)
    {
        if (index >= 0 && index < gameObjects.Length)
        {
            gameObjects[index].SetActive(state);
        }
    }
}