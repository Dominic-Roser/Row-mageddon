using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
        GetComponent<Button>().onClick.AddListener(RetryLevel);   
    }

    // Update is called once per frame
    void RetryLevel()
    {
        PauseButton.unpauseGame();
        if (PlayerData.playerLevel == 0)
        {
            PlayerData.selectedPowerupSprites[0] = PlayerData.powerupIconDictionary["FishingRod"];
            PlayerData.selectedVariablesCT[0] = true;
            PlayerData.SelectedPowerupNames[0] = "FishingRod";
            SceneManager.LoadScene("newRacing");
        }
        else
        {
            SceneManager.LoadScene("RacePlan");
        }
    }
}
