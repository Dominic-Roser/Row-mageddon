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
        // if (!string.IsNullOrEmpty(PlayerData.levelToLoad))
        // {
            // SceneManager.LoadScene(PlayerData.levelToLoad);
            SceneManager.LoadScene("DomPowerUp");

        // }
        // else
        // {
        //     Debug.LogWarning("No level selected! Defaulting to 'DomPowerUp'.");
        //     // SceneManager.LoadScene("DomPowerUp"); // lets put some default scene here in case
        // }
    }
}
