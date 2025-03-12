using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using System;

public class Placing : MonoBehaviour
{
    private Dictionary<RaceProgressTracker, float> boatProgress = new Dictionary<RaceProgressTracker, float>();
    private RaceProgressTracker[] boats;
    private TextMeshProUGUI positionText;


    void Start()
    {
        positionText = GetComponent<TextMeshProUGUI>();

        if (positionText == null)
        {
            Debug.LogError("RaceManager: No TMP found on this GameObject");
            return;
        }

        // Find all the boats by looking for objects with the RaceProgressTracker script
        boats = FindObjectsByType<RaceProgressTracker>(FindObjectsSortMode.None);
    }

    void Update()
    {

        // Update progress for each boat
        boatProgress.Clear();
        foreach (var boat in boats)
        {
            boatProgress[boat] = boat.RaceProgress;
        }

        // Sort boats by their progress 
        var sortedBoats = boatProgress.OrderByDescending(b => b.Value).ToList();

        // Find the placing of the player boat
        int position = sortedBoats.FindIndex(b => b.Key.gameObject.name == "Boat") + 1;

        // Update the UI text
        positionText.text = GetOrdinal(position);

        // Get player's progress
        RaceProgressTracker playerBoat = boats.FirstOrDefault(b => b.gameObject.name == "Boat");

        float playerProgress = playerBoat.RaceProgress;

        // Adjust enemy speeds based on their distance from the player
        foreach (var entry in sortedBoats)
        {
            RaceProgressTracker enemyBoat = entry.Key;
            if (enemyBoat.gameObject.name == "Boat") continue; // Skip player boat

            float enemyProgress = entry.Value;
            float progressDifference = Mathf.Abs(enemyProgress - playerProgress);

            // Only do speed adjustment if the speed difference is greater than 2%
            if (progressDifference > 2f) 
            {
                enemyBoat.GetComponent<enemyPath>().AdjustSpeedBasedOnPosition(playerProgress, enemyProgress);
            }
            else if (enemyBoat.GetComponent<enemyPath>().IsSpeedAdjusted)
            {
                Debug.Log("Enemy boat speed has been reset");
                enemyBoat.GetComponent<enemyPath>().ResetSpeed(); 
            }
        }
    }

    // Returns the correct format for the placing
    private string GetOrdinal(int number)
    {
        if (number == 1) return number + "st";
        if (number == 2) return number + "nd";
        if (number == 3) return number + "rd";
        return number + "th";
    }
}
