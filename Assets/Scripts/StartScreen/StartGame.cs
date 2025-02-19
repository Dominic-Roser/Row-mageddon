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
        start.onClick.AddListener(NewGame);
        audioplayer = GameObject.Find("StartButton");
        
    }

    // Update is called once per frame
    public void NewGame()
    {
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
        SceneManager.LoadScene("RowingTutorial");
    }

    async void startAnalyticsCollection() {
        await UnityServices.InitializeAsync();

        Debug.Log($"Started UGS Analytics Sample with user ID: {AnalyticsService.Instance.GetAnalyticsUserID()}");
        AnalyticsService.Instance.StartDataCollection();
        Debug.Log($"Consent has been provided. The SDK is now collecting data!");
    }

    public static void recordGameEntered() {
        GameStartClick startEvent = new GameStartClick
        {
            started = true
        };

        AnalyticsService.Instance.RecordEvent(startEvent);
        Debug.Log("Game started event logged");
    }
}
