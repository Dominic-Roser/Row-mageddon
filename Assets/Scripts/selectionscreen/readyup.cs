using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class readyup : MonoBehaviour
{
    public Button button;
    
    void Start()
    {
        button.onClick.AddListener(Ready);
    }

    // Update is called once per frame
    void Ready()
    {
        PlayerData.maxSpeed = BoatData.boatMaxSpeed[PlayerData.boatName];
        PlayerData.boostAmount = BoatData.boatBoostAmount[PlayerData.boatName];
        recordLevelStartedEvent(PlayerData.playerLevel, PlayerData.levelToLoad, PlayerData.SelectedPowerupNames, "");
        SceneManager.LoadScene(PlayerData.levelToLoad);
    }
    public static void recordLevelStartedEvent(int playerLevel, string chosenLevel, string[] chosenPowerups, string chosenBoat) {
        if (AnalyticsData.analyticsActive) {
            LevelStartedEvent levelStartedEvent = new LevelStartedEvent
            {
                playerLevel = playerLevel,
                chosenPowerups = chosenPowerups,
                chosenLevel = chosenLevel,
                chosenBoat = chosenBoat
            };

            AnalyticsService.Instance.RecordEvent(levelStartedEvent);
            Debug.Log("Level started event logged");
        } else {
            Debug.Log("Analytics inactive - nothing to log");
        }
    }
}
