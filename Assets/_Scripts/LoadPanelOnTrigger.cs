using UnityEngine;

public class LoadPanelOnTrigger : MonoBehaviour
{
    public GameObject panelToLoad; // Reference to the panel you want to load

    public void Start()
    {
        panelToLoad.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the panelToLoad is assigned
            if (panelToLoad != null)
            {
                panelToLoad.SetActive(true); // Activate the panel
            }
            else
            {
                Debug.LogWarning("Panel to load is not assigned in the inspector.");
            }
        }
    }
}
