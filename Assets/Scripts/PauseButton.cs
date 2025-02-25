using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    // Reference to UI elements
    private GameObject retryButton;
    private GameObject exitButton;

    private Sprite playSprite;
    private Sprite pauseSprite;

    // Start is called before the first frame update
    void Start() {
      // Ensure the pause menu and extra buttons are hidden initially
      retryButton = GameObject.Find("UI/PauseHUD/RetryButton");
      exitButton = GameObject.Find("UI/PauseHUD/ExitButton");
      retryButton.SetActive(false);
      exitButton.SetActive(false);
      playSprite = Resources.Load<Sprite>("Materials/resumebutton");
      pauseSprite = Resources.Load<Sprite>("Materials/pause");

      // Set up button listeners
      GetComponent<Button>().onClick.AddListener(TogglePause);
    }

    // Toggle the paused state and show/hide the pause menu
    void TogglePause() {
        Debug.Log("Pause button clicked");
        PlayerData.gamePaused = !PlayerData.gamePaused;
        if (PlayerData.gamePaused) {
          pauseGame();
          retryButton.SetActive(true);
          exitButton.SetActive(true);
          GetComponent<Image>().sprite = playSprite;
        } else {
          unpauseGame(); 
          retryButton.SetActive(false);
          exitButton.SetActive(false); 
          GetComponent<Image>().sprite = pauseSprite;
                
        }
    }
    public static void pauseGame() {
      PlayerData.gamePaused = true;
      Time.timeScale = 0f;
    }
    public static void unpauseGame() {
      PlayerData.gamePaused = false;
      Time.timeScale = 1f;
    }
}
