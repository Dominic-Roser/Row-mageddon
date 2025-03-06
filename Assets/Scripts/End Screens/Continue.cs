using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using TMPro;

public class Continue : MonoBehaviour
{
    private GameObject goldTextBox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int goldWon;
    void Start()
    {
        LevelData.coinsAlreadyCollected[PlayerData.levelToLoad] = coin.currCollected;
        goldTextBox = GameObject.Find("Canvas/GoldAmount");
        if (GetLevelNumber(PlayerData.levelToLoad) == PlayerData.playerLevel || PlayerData.levelToLoad == "newRacing") {
            goldWon = LevelData.levelNewCompletionGoldRewards[PlayerData.levelToLoad] + PlayerData.collectedCoins;
        } else {
            goldWon = LevelData.levelStaleCompletionGoldRewards[PlayerData.levelToLoad] + PlayerData.collectedCoins;
        }
        goldTextBox.GetComponent<TextMeshProUGUI>().text = "+  " + goldWon + " Gold";
        PlayerData.collectedCoins = 0;
        GetComponent<Button>().onClick.AddListener(ContinueToOverworld);   
    }

    // Update is called once per frame
    void ContinueToOverworld()
    {
        if (PlayerData.levelToLoad == "Level16")
        {
            PlayerData.playerLevel++;
            PlayerData.gold += goldWon;
            FinishLine.ResetPlayerAndEnemyData();
            PlayerData.SaveData();
            SceneManager.LoadScene("End Scene");
        }
        else
        {
            if (GetLevelNumber(PlayerData.levelToLoad) == PlayerData.playerLevel || PlayerData.levelToLoad == "newRacing")
            {
                PlayerData.playerLevel++;
                PlayerData.gold += goldWon;
                PlayerData.boatName = "WoodenBoat";
            }
            else
            {
                PlayerData.gold += goldWon;
            }
            FinishLine.ResetPlayerAndEnemyData();
            PlayerData.SaveData();
            SceneManager.LoadScene("OverWorld Map");
        }
    }

    public static int GetLevelNumber(string levelName) {
        // Use regex to extract the digits at the end of the string
        Match match = Regex.Match(levelName, @"\d+$");
        if (match.Success) {
            return int.Parse(match.Value);
        } else {
            Debug.LogWarning("No number found at the end of the string.");
            return -1; // Return -1 if no number is found
        }
    }
}
