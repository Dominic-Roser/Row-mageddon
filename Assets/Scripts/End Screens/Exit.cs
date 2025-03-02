using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Services.Analytics;
public class Exit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerData.collectedCoins = 0;
        GetComponent<Button>().onClick.AddListener(ExitLevel);   

    }

    // Update is called once per frame
    void ExitLevel()
    {
        recordExitEvent();
        PauseButton.unpauseGame();
        FinishLine.ResetPlayerAndEnemyData();
        if (PlayerData.playerLevel == 0)
        {

            SceneManager.LoadScene("StartScreen");
        } else
        {
            SceneManager.LoadScene("OverWorld Map");
        }
   
    }

    public static void recordExitEvent() {
        if (AnalyticsData.analyticsActive) {
            QuitToMapEvent tutorialEndedEvent = new QuitToMapEvent
            {
                playerLevel = PlayerData.playerLevel,
                chosenLevel = PlayerData.levelToLoad,
                chosenBoat = PlayerData.boatName,
                chosenPowerups = PlayerData.SelectedPowerupNames,
                timeInLevel = 0f
            };

            AnalyticsService.Instance.RecordEvent(tutorialEndedEvent);
            Debug.Log("Racing Tutorial started event logged");
        } else {
            Debug.Log("Analytics inactive - nothing to log");
        }
    }
}
