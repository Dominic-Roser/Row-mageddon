using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (PlayerData.playerLevel == 0) {
            PlayerData.boatName = "Grandpa";
        }
        if(other.gameObject.name == "Boat") {
            PlayerData.lapscompleted++;
            if (PlayerData.lapscompleted == LevelData.TotalLaps[PlayerData.levelToLoad]) {
                //Log true on a win TODO make a timer and a chosen boat to pass in as params
                recordLevelEndedEvent(PlayerData.playerLevel, PlayerData.levelToLoad, PlayerData.SelectedPowerupNames, true, 0f, PlayerData.boatName);
                ResetPlayerAndEnemyData();
                SceneManager.LoadScene("WinScene");
            }
        } else if (other.gameObject.name == "EnemyBoat"){
            EnemyData.lapscompleted++;
            if (EnemyData.lapscompleted == LevelData.TotalLaps[PlayerData.levelToLoad]){ // if the player doesn't get there first
                recordLevelEndedEvent(PlayerData.playerLevel, PlayerData.levelToLoad, PlayerData.SelectedPowerupNames, false, 0f, PlayerData.boatName);
                ResetPlayerAndEnemyData();
                SceneManager.LoadScene("LoseScene");
            }
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

    public static void ResetPlayerAndEnemyData() {
        PlayerData.lapscompleted = 0;
        EnemyData.lapscompleted = 0;
        PlayerData.SelectedPowerupNames = new string[4];
        PlayerData.selectedVariablesCT = new bool[4];
    }
}