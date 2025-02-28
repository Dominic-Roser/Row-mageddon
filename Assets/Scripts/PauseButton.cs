using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    // Reference to UI elements
    private GameObject retryButton;
    private GameObject exitButton;

    private GameObject pauseButton;
    
    private GameObject buttonGraphics;

    // Start is called before the first frame update
    void Start() {
      // Ensure the pause menu and extra buttons are hidden initially
      retryButton = GameObject.Find("UI/PauseHUD/RetryButton");
      exitButton = GameObject.Find("UI/PauseHUD/ExitButton");
      buttonGraphics = GameObject.Find("UI/PauseHUD/ButtonGraphics");
      pauseButton = GameObject.Find("UI/PauseHUD/PauseButton");
      pauseButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(-53f, 952f, 0f);
      retryButton.SetActive(false);
      exitButton.SetActive(false);
      buttonGraphics.SetActive(false);
      pauseButton.SetActive(true);


      // Set up button listeners
      GetComponent<Button>().onClick.AddListener(TogglePause);
    }

    // Toggle the paused state and show/hide the pause menu
 void TogglePause() {
        Debug.Log("Pause button clicked");
        PlayerData.gamePaused = !PlayerData.gamePaused;
        if (PlayerData.gamePaused) {
          pauseGame();
          buttonGraphics.SetActive(true);
          retryButton.SetActive(true);
          exitButton.SetActive(true);
          pauseButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("TinsleyPieces/ResumeButton");
          pauseButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(152f, 561f, 0f);
          pauseButton.GetComponent<RectTransform>().sizeDelta = new Vector3(130f, 25f);


        } else {
          unpauseGame(); 
          pauseButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("TinsleyPieces/PauseButton");
          retryButton.SetActive(false);
          exitButton.SetActive(false);
          buttonGraphics.SetActive(false);
          pauseButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(-53f, 952f, 0f);
          pauseButton.GetComponent<RectTransform>().sizeDelta = new Vector3(106f, 25f);

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
