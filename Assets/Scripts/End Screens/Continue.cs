using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class Continue : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ContinueToOverworld);   
    }

    // Update is called once per frame
    void ContinueToOverworld()
    {
        PlayerData.gold += 5;
        if(GetLevelNumber(PlayerData.levelToLoad) == PlayerData.playerLevel) {
            PlayerData.playerLevel++;
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
