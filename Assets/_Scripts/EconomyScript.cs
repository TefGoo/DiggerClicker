using TMPro;
using UnityEngine;

public class EconomyScript : MonoBehaviour
{
    public TMP_Text pointsText; // Reference to the TMP Text for displaying points
    private int points; // Player's points

    private void Start()
    {
        LoadPlayerPrefs();
        UpdatePointsDisplay();
    }

    public void AddPoints(int amount)
    {
        points += amount;
        UpdatePointsDisplay();
        SavePlayerPrefs();
    }

    public int GetPoints()
    {
        return points;
    }

    public void DeductPoints(int amount)
    {
        points -= amount;
        UpdatePointsDisplay();
        SavePlayerPrefs();
    }

    private void UpdatePointsDisplay()
    {
        pointsText.text = "Points: " + points.ToString();
    }

    private void SavePlayerPrefs()
    {
        PlayerPrefs.SetInt("PlayerPoints", points);
    }

    private void LoadPlayerPrefs()
    {
        points = PlayerPrefs.GetInt("PlayerPoints", 0);
    }
}
