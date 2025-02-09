using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartGame : MonoBehaviour
{
    public Button start;
    private GameObject audioplayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        SceneManager.LoadScene("DomTutorial");
    }
}
