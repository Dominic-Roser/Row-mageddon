using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if the player gets there first
        if (other.gameObject.name == "Boat")
        {
            //Log true on a win TODO make a timer and a chosen boat to pass in as params
            recordLevelEndedEvent(PlayerData.playerLevel, PlayerData.levelToLoad, PlayerData.SelectedPowerupNames, true, 0f, "");
            ResetPlayerData();
            SceneManager.LoadScene("WinScene");
        } else { // if the player doesn't get there first
            recordLevelEndedEvent(PlayerData.playerLevel, PlayerData.levelToLoad, PlayerData.SelectedPowerupNames, false, 0f, "");
            ResetPlayerData();
            SceneManager.LoadScene("LoseScene");
        }
    }

    public static void recordLevelEndedEvent(int playerLevel, string chosenLevel, string[] chosenPowerups, bool win, float timeInLevel, string chosenBoat) {
        if(AnalyticsData.analyticsActive){
            LevelEndedEvent levelEndedEvent = new LevelEndedEvent
            {
                win = win,
                playerLevel = playerLevel,
                chosenPowerups = chosenPowerups,
                chosenLevel = chosenLevel,
                timeInLevel = timeInLevel,
                chosenBoat = chosenBoat
            };

            AnalyticsService.Instance.RecordEvent(levelEndedEvent);
            Debug.Log("Level ended event logged");
        } else {
            Debug.Log("Analytics inactive - nothing to log");
        }
    }

    void ResetPlayerData() {
        PlayerData.SelectedPowerupNames = new string[4];
        PlayerData.selectedVariablesCT = new bool[4];
    }
}