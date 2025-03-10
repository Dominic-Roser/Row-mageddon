using TMPro;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private bool boatinside;
    private GameObject lapcountertmp;
    private void OnTriggerExit2D(Collider2D other)
    {
        lapcountertmp = GameObject.Find("UI/LapCounter");
        if(PlayerData.halfwaycheckpointcrossed && other.gameObject.name == "Boat" && boatinside) {
            PlayerData.lapscompleted++;
            PlayerData.halfwaycheckpointcrossed = false;
            boatinside = false;
            lapcountertmp.GetComponent<TextMeshProUGUI>().text = "Lap " + (PlayerData.lapscompleted+1) + "/" + (LevelData.TotalLaps[PlayerData.levelToLoad]);
        } else if ((!PlayerData.halfwaycheckpointcrossed) && other.gameObject.name == "Boat" && boatinside) {
            Debug.Log("Dont cheat");
            boatinside = false;
        }
        if (other.gameObject.tag == "Enemy"){
            other.gameObject.GetComponent<EnemyData>().lapscompleted++;
            Debug.Log(other.gameObject.name+" laps completed: " + other.gameObject.GetComponent<EnemyData>().lapscompleted);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        int totallaps = LevelData.TotalLaps[PlayerData.levelToLoad];
        Debug.Log("Total laps: "+ totallaps + " laps completed: "+ PlayerData.lapscompleted);
        if (PlayerData.playerLevel == 0) {
            PlayerData.boatName = "Grandpa";
        }
        if(other.gameObject.name == "Boat") {
            boatinside = true;
            if (PlayerData.halfwaycheckpointcrossed && (totallaps == 1 || PlayerData.lapscompleted == totallaps-1)) {
                //Log true on a win TODO make a timer and a chosen boat to pass in as params
                recordLevelEndedEvent(PlayerData.playerLevel, PlayerData.levelToLoad, PlayerData.SelectedPowerupNames, true, GameManager.instance.GetRaceTime(), PlayerData.boatName);
                ResetPlayerAndEnemyData();
                SceneManager.LoadScene("WinScene");
            }
        } else if (other.gameObject.tag == "Enemy"){
            //EnemyData.lapscompleted++;
            if (totallaps == 1 || other.gameObject.GetComponent<EnemyData>().lapscompleted == totallaps-1){ // if the player doesn't get there first
                recordLevelEndedEvent(PlayerData.playerLevel, PlayerData.levelToLoad, PlayerData.SelectedPowerupNames, false, GameManager.instance.GetRaceTime(), PlayerData.boatName);
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
        PlayerData.halfwaycheckpointcrossed = false;
        PlayerData.lapscompleted = 0;
        //EnemyData.lapscompleted = 0;
        PlayerData.SelectedPowerupNames = new string[4];
        PlayerData.selectedVariablesCT = new bool[4];
    }
}