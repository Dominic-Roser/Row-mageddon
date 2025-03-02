using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStates { countDown, running, raceOver};
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    GameStates gameState = GameStates.countDown;
    // Makes suer there is only one game manager at a time
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60; // cap frame rate to avoid tunneling
    }

    void LevelStart()
    {
        gameState = GameStates.countDown;

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
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LevelStart();
    }
}
