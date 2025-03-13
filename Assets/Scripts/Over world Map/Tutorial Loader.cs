using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialLoader : MonoBehaviour
{

    public void LoadScene(string levelName)
    {
        Debug.Log("Loading scene: " + levelName);
        PlayerData.levelToLoad = "RowingTutorial";
        SceneManager.LoadScene(levelName);
    }
}

