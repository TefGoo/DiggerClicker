using System.Collections;
using UnityEngine;

public class AchievementScript : MonoBehaviour
{
    public GameObject panelToLoad; // Reference to the panel you want to load
    public float moveDownDistance = 2f; // Distance to move the panel down
    public float moveDuration = 1f; // Duration to move down
    public float stayDuration = 3f; // Duration to stay in the down position
    public float moveUpDuration = 1f; // Duration to move back up
    public float colliderDeactivateDelay = 0.5f; // Delay before deactivating the collider

    private Vector3 originalLocalPosition; // Original local position of the panel
    private BoxCollider2D boxCollider2D; // Reference to the BoxCollider2D component

    private void Start()
    {
        // Store the original local position of the panel
        originalLocalPosition = panelToLoad.transform.localPosition;
        panelToLoad.SetActive(false);

        // Get the BoxCollider2D component
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Activate the panel
            panelToLoad.SetActive(true);

            // Start the move panel sequence
            StartCoroutine(MovePanelSequence());

            // Deactivate the collider after a delay
            StartCoroutine(DeactivateCollider());
        }
    }

    private IEnumerator MovePanelSequence()
    {
        // Move down in local space
        LeanTween.moveLocalY(panelToLoad, originalLocalPosition.y - moveDownDistance, moveDuration);

        // Wait for the specified duration
        yield return new WaitForSeconds(moveDuration);

        // Stay in the down position
        yield return new WaitForSeconds(stayDuration);

        // Move up in local space
        LeanTween.moveLocalY(panelToLoad, originalLocalPosition.y, moveUpDuration);

        // Wait for the specified duration
        yield return new WaitForSeconds(moveUpDuration);

        // Deactivate the panel
        panelToLoad.SetActive(false);
    }

    private IEnumerator DeactivateCollider()
    {
        // Wait for the specified delay before deactivating the collider
        yield return new WaitForSeconds(colliderDeactivateDelay);

        // Deactivate the BoxCollider2D
        if (boxCollider2D != null)
        {
            boxCollider2D.enabled = false;
        }
    }
}
