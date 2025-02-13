using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public string sceneName; 

    void Start()
    {
        sceneName = "SeanLevelOne";
        // Attach the Button's click event
        GetComponent<Button>().onClick.AddListener(LoadScene);
    }

    void LoadScene()
    {
        Debug.Log("Loading scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
}
