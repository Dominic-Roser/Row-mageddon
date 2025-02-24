using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using TMPro;

public class Continue : MonoBehaviour
{
    private GameObject goldTextBox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        goldTextBox = GameObject.Find("Canvas/GoldAmount");
        if (GetLevelNumber(PlayerData.levelToLoad) == PlayerData.playerLevel || PlayerData.levelToLoad == "newRacing") {
            goldTextBox.GetComponent<TextMeshProUGUI>().text = "+  " + PlayerData.levelNewCompletionGoldRewards[PlayerData.levelToLoad] + " Gold";
        } else {
            goldTextBox.GetComponent<TextMeshProUGUI>().text = "+  " + PlayerData.levelStaleCompletionGoldRewards[PlayerData.levelToLoad] + " Gold";
        }
        GetComponent<Button>().onClick.AddListener(ContinueToOverworld);   
    }

    // Update is called once per frame
    void ContinueToOverworld()
    {
        if(GetLevelNumber(PlayerData.levelToLoad) == PlayerData.playerLevel || PlayerData.levelToLoad == "newRacing") {
            PlayerData.playerLevel++;
            PlayerData.gold += PlayerData.levelNewCompletionGoldRewards[PlayerData.levelToLoad];
        } else {
            PlayerData.gold += PlayerData.levelStaleCompletionGoldRewards[PlayerData.levelToLoad];
        }
            SceneManager.LoadScene("OverWorld Map");
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
