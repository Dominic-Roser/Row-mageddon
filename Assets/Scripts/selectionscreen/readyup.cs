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
        // Debug.Log("Loading selected level: " + PlayerData.levelToLoad);
        // if (SceneManager.GetSceneByName(PlayerData.levelToLoad) )
        // {
        PlayerData.previousScene = SceneManager.GetActiveScene().name;
        recordLevelStartedEvent(PlayerData.playerLevel, PlayerData.levelToLoad, PlayerData.SelectedPowerupNames, "");
        SceneManager.LoadScene(PlayerData.levelToLoad);
        //SceneManager.LoadScene("DomPowerUp");

        // }
        // else
        // {
        //     Debug.LogWarning("No level selected! Defaulting to 'DomPowerUp'.");
        //     SceneManager.LoadScene("DomPowerUp"); // lets put some default scene here in case
        // }
    }
    public static void recordLevelStartedEvent(int playerLevel, string chosenLevel, string[] chosenPowerups, string chosenBoat) {
        LevelStartedEvent levelStartedEvent = new LevelStartedEvent
        {
            playerLevel = playerLevel,
            chosenPowerups = chosenPowerups,
            chosenLevel = chosenLevel,
            chosenBoat = chosenBoat
        };

        AnalyticsService.Instance.RecordEvent(levelStartedEvent);
        Debug.Log("Level started event logged");
    }
}
