using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.Services.Core;
using Unity.Services.Analytics;


public class StartGame : MonoBehaviour
{
    public Button start;
    private GameObject audioplayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startAnalyticsCollection();
        PlayerData.LoadData();

        start.onClick.AddListener(NewGame);
        audioplayer = GameObject.Find("StartButton");
        AnalyticsData.analyticsActive = true;
    }

    // Update is called once per frame
    public void NewGame()
    {
        recordTutorialStarted();
        StartCoroutine(PlayAudioAndLoadScene());
    }

    private IEnumerator PlayAudioAndLoadScene()
    {
        AudioSource audioSource = audioplayer.GetComponent<AudioSource>();
        audioSource.Play();

        // Wait until the audio finishes playing
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        recordGameEntered();
        if (PlayerData.playerLevel==0) {
            PlayerData.levelToLoad = "RowingTutorial";
            SceneManager.LoadScene("RowingTutorial");
        } else {
            SceneManager.LoadScene("OverWorld Map");
        }
    }

    async void startAnalyticsCollection() {
        await UnityServices.InitializeAsync();

        Debug.Log($"Started UGS Analytics Sample with user ID: {AnalyticsService.Instance.GetAnalyticsUserID()}");
        AnalyticsService.Instance.StartDataCollection();
        Debug.Log($"Consent has been provided. The SDK is now collecting data!");
        AnalyticsData.analyticsActive = true;
    }

    public static void recordGameEntered() {
        if (AnalyticsData.analyticsActive) {
            GameStartClick startEvent = new GameStartClick
            {
                started = true
            };

            AnalyticsService.Instance.RecordEvent(startEvent);
            Debug.Log("Game started event logged");
        } else {
            Debug.Log("Analytics inactive - nothing to log");
        }
    }
    public static void recordTutorialStarted() {
        if (AnalyticsData.analyticsActive) {
            LevelStartedEvent tutorialStartEvent = new LevelStartedEvent
            {
                playerLevel = 0,
                chosenLevel = "RowingTutorial",
                chosenBoat = "Grandpa",
                chosenPowerups = new string [4]{"", "", "", ""}
            };

            AnalyticsService.Instance.RecordEvent(tutorialStartEvent);
            Debug.Log("RowingTutorial started event logged");
        } else {
            Debug.Log("Analytics inactive - nothing to log");
        }
    }
}
