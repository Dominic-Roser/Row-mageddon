using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    

    public void LoadScene(string levelName)
    {
        Debug.Log("Setting levelToLoad in PlayerData: " + levelName);
        PlayerData.levelToLoad = levelName;
        PlayerData.previousScene = SceneManager.GetActiveScene().name;
        UnityEngine.SceneManagement.SceneManager.LoadScene("RacePlan"); 
    }
}
