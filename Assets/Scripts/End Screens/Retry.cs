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
        if(PlayerData.levelToLoad == "newRacing" || PlayerData.levelToLoad == "RowingTutorial"){
            FinishLine.ResetPlayerAndEnemyData();
            PlayerData.SelectedPowerupNames[0] = "FishingRod";
            PlayerData.selectedPowerupSprites[0] = Resources.Load<Sprite>("Materials/PowerUpIcons/fishingRod");
            PlayerData.selectedVariablesCT[0] = true;
            recordRetryEvent();
            PauseButton.unpauseGame();
            SceneManager.LoadScene(PlayerData.levelToLoad);
        } else {
            recordRetryEvent();
            PauseButton.unpauseGame();
            FinishLine.ResetPlayerAndEnemyData();
            if (PlayerData.playerLevel == 0)
            {
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
