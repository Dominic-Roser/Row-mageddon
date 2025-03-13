using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Services.Analytics;

public class Retry : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
        PlayerData.collectedCoins = 0;
        GetComponent<Button>().onClick.AddListener(RetryLevel);   
    }

    // Update is called once per frame
    void RetryLevel()
    {
        Debug.Log("REtrying: " + PlayerData.levelToLoad);
        recordRetryEvent();
        PauseButton.unpauseGame();
        FinishLine.ResetPlayerAndEnemyData();
        if (PlayerData.playerLevel == 0)
        {
            Debug.Log("Reloading: " + PlayerData.levelToLoad);
            PlayerData.selectedPowerupSprites[0] = PlayerData.powerupIconDictionary["FishingRod"];
            PlayerData.selectedVariablesCT[0] = true;
            PlayerData.SelectedPowerupNames[0] = "FishingRod";
            SceneManager.LoadScene(PlayerData.levelToLoad);
        }
        else
        {
            SceneManager.LoadScene("RacePlan");
        }
    }

    public static void recordRetryEvent() {
        if (AnalyticsData.analyticsActive) {
            RetryEvent tutorialEndedEvent = new RetryEvent
            {
                playerLevel = PlayerData.playerLevel,
                chosenLevel = PlayerData.levelToLoad,
                chosenBoat = PlayerData.boatName,
                chosenPowerups = PlayerData.SelectedPowerupNames,
                timeInLevel = 0f
            };

            AnalyticsService.Instance.RecordEvent(tutorialEndedEvent);
            Debug.Log("retry event logged");
        } else {
            Debug.Log("Analytics inactive - nothing to log");
        }
    }
}
