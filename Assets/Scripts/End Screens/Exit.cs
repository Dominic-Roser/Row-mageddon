using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
        PauseButton.unpauseGame();
        if (PlayerData.playerLevel == 0)
        {

            SceneManager.LoadScene("StartScreen");
        } else
        {
            SceneManager.LoadScene("OverWorld Map");
        }
   
    }
}
