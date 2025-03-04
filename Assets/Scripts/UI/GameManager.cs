using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStates { countDown, running, raceOver };
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public static GameObject boat;

    private float raceTimer = 0f; // Timer variable
    private bool isTimerRunning = false; // Track if timer is running

    GameStates gameState = GameStates.countDown;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        PlayerData.levelToLoad = SceneManager.GetActiveScene().name;
    }

    void Start()
    {
        Application.targetFrameRate = 60; // Cap frame rate
    }

    void Update()
    {
        if (isTimerRunning)
        {
            raceTimer += Time.deltaTime; // Increment timer
        }
    }

    void LevelStart()
    {
        gameState = GameStates.countDown;
        raceTimer = 0f; // Reset timer at level start
        isTimerRunning = false; // Ensure timer doesn't start immediately

        Debug.Log("Level Started");
    }

    public GameStates GetGameState()
    {
        return gameState;
    }

    public void OnRaceStart()
    {
        Debug.Log("OnRaceStart");

        gameState = GameStates.running;
        isTimerRunning = true; // Start the timer
    }

    public void OnRaceEnd()
    {
        Debug.Log("OnRaceEnd");

        gameState = GameStates.raceOver;
        isTimerRunning = false; // Stop the timer
    }

    public float GetRaceTime()
    {
        return raceTimer;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LevelStart();
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            Debug.Log("Player has left tab and data saved")
            PlayerData.SaveData();
        }
    }
    void OnApplicationQuit()
    {
        Debug.Log("Application Quit and data saved");
        PlayerData.SaveData();
    }
